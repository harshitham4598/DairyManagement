using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MilkDairy.Models
{
    public class ExportToMainDairy
    {
        queryExecitor que;

        public decimal slno{ get; set; }

        [Display(Name = "Dairy Name")]
        [Required(ErrorMessage = "Required*")]
        public string dairy_name { get; set; }
 
   
        [Display(Name = "Session")]
        [Required(ErrorMessage = "Required*")]
        public string session { get; set; }


        [Display(Name = "Litre")]
        [Required(ErrorMessage = "Required*")]
        public decimal litre { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Required*")]
        public decimal price { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Required*")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? date { get; set; }

        [Display(Name = "Total Amount")]
        [Required(ErrorMessage = "Required*")]
        public decimal total_amt { get; set; }

        [Display(Name = "SNF")]
        [Required(ErrorMessage = "Required*")]
        public string snf { get; set; }

        [Display(Name = "FAT")]
        [Required(ErrorMessage = "Required*")]
        public string fat { get; set; }

        public List<Prices> prices_amt { get; set; }

        public List<Society_Creation> dairys { get; set; }


        public string created_by { get; set; }
        public string updated_by { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }


        public bool Add()
        {
            que = new queryExecitor();
            return que.Transaction(string.Format("insert into exported_dairy(dairy_name,session,litre,price,date,total_amt,snf,fat,created_by,created_on)" +
                  " values  ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')"
                  , this.dairy_name, this.session, this.litre, this.price, this.date, this.total_amt, this.snf, this.fat, this.created_by, this.created_on)) > 0;
        }


        public bool Update()
        {
            que = new queryExecitor();
            return que.Transaction(
               string.Format(
                "Update exported_dairy set " +
                "dairy_name='{0}',session='{1}',litre='{2}',price='{3}',date='{4}',total_amt='{5}'," +
                "snf = '{6}', fat = '{7}', updated_by = '{8}', updated_on = '{9}' where slno='{10}'"
               , this.dairy_name, this.session, this.litre, this.price, this.date, this.total_amt, this.snf, this.fat, this.updated_by, this.updated_on, this.slno)) > 0;
        }

        public List<ExportToMainDairy> Fetch()
        {
            que = new queryExecitor();
            return DataConvertor.ConvertDataTable<ExportToMainDairy>(
                que.NonTransaction("Select * from exported_dairy"));
        }
 

        public bool Delete(string id)
        {
            que = new queryExecitor();
            return que.Transaction(
            string.Format("delete from exported_dairy where slno='{0}'", id)) > 0;
        }

        public ExportToMainDairy Edit(int id)
        {
            que = new queryExecitor();
            List<ExportToMainDairy> result = DataConvertor
                .ConvertDataTable<ExportToMainDairy>(que
                .NonTransaction("Select * from exported_dairy where slno=" + id));

            return result.Count != 0 ? result[0] : null;
        }



    }
}