using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MilkDairy.Models
{
    public class MilkAquirements
    {

        #region variables

        queryExecitor que;
        public decimal slno { get; set; }
        [Display(Name = "Member ID")]
        [Required(ErrorMessage = "Required*")]
        public string member_id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Required*")]
        public string member_name { get; set; }
        [Display(Name = "Session")]
        [Required(ErrorMessage = "Required*")]
        public string session { get; set; }


       // [Display(Name = "Acc No")]
       // //[Required(ErrorMessage = "*")]
       // public string acc_no { get; set; }
       // [Display(Name = "IFSC")]
       //// [Required(ErrorMessage = "*")]
       // public string ifsc { get; set; }
       // [Display(Name = "Phone")]
       // //  [Required(ErrorMessage = "*")]
       // public string phone { get; set; }

        [Display(Name = "Cattle Type")]
        [Required(ErrorMessage = "Required*")]
        public string cattle_type { get; set; }
        [Display(Name = "Litre")]
        [Required(ErrorMessage = "Required*")]
        public string litre { get; set; }
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
        [Display(Name = "Father Name")]
        [Required(ErrorMessage = "Required*")]
        public string nominee_name  { get; set; }

        public string status { get; set; }


        public string created_by { get; set; }
        public string updated_by { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }

        public List<Prices> prices_amt { get; set; }

        #endregion




        public bool Add()
        {
            que = new queryExecitor();
            return que.Transaction(string.Format("insert into milk_aquirement( member_id, member_name, session,   " +
                "  cattle_type, litre, price, date, " +
                "total_amt, snf ,fat,nominee_name, created_on, created_by,status )" +
                  " values  ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')"
                  , this.member_id, this.member_name, this.session,  
                 this.cattle_type, this.litre, this.price, this.date,
                  this.total_amt, this.snf, this.fat,this.nominee_name, this.created_on , this.created_by,this.status)) > 0;
        }
        

        //public bool Update()
        //{
        //    que = new queryExecitor();
        //    return que.Transaction(
        //       string.Format(
        //        "Update member_master set " +
        //        "updated_by='{0}',member_name='{1}',nominee_name='{2}',dob='{3}',pan_card='{4}',gender='{5}'," +
        //        "phone_no = '{6}', address = '{7}', bank_name = '{8}', acc_no = '{9}'," +
        //        "ifsc = '{10}',adhar_no = '{11}',updated_on = '{12}' where member_id='{13}'"
        //        , this.updated_by, this.member_name, this.nominee_name, this.dob, this.pan_card,
        //        this.gender, this.phone_no, this.address, this.bank_name, this.acc_no, this.ifsc, this.adhar_no, this.updated_on, this.member_id)) > 0;
        //}

        public List<MilkAquirements> Fetch()
        {
            que = new queryExecitor();
            return DataConvertor.ConvertDataTable<MilkAquirements>(
                que.NonTransaction("Select * from milk_aquirement"));
        }

        public MilkAquirements getIndividualMilkAquirement(string id)
        {
            que = new queryExecitor();
            List<MilkAquirements> result = DataConvertor
                .ConvertDataTable<MilkAquirements>(que
                .NonTransaction("Select * from milk_aquirement where slno='" + id + "'"));
            return result.Count != 0 ? result[0] : null;
        }


        public List<MilkAquirements> FetchTodaysList()
        {
            que = new queryExecitor();
            return DataConvertor.ConvertDataTable<MilkAquirements>(
                que.NonTransaction("select * from milk_aquirement where date=CURRENT_DATE ORDER BY slno DESC"));
        }

        public bool Delete(string id)
        {
            que = new queryExecitor();
            return que.Transaction(
            string.Format("delete from milk_aquirement where slno='{0}'", id)) > 0;
        }

    }
}