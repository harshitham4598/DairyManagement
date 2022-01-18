using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MilkDairy.Models
{
    public class RetailSale
    {
        queryExecitor que;

        public decimal slno { get; set; }
        [Display(Name = "Session")]
        [Required(ErrorMessage = "Required*")]
        public string session { get; set; }
        [Display(Name = "Litre")]
        [Required(ErrorMessage = "Required*")]
        public decimal litre { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Required*")]
        public decimal price { get; set; }
        [Display(Name = "Total")]
        [Required(ErrorMessage = "Required*")]
        public decimal total { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Required*")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        [Display(Name = "Payment")]
        [Required(ErrorMessage = "Required*")]
        public string payment { get; set; }
        [Display(Name = "Member ID")]
    
        public string member_id { get; set; }
        public string status { get; set; }

        public string created_by { get; set; }
        public string updated_by { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }
        public List<Prices> prices_amt { get; set; }


         
        public bool Add()
        {
            que = new queryExecitor();
            return que.Transaction(string.Format("insert into retail( session, litre,price, total,   " +
                " date, payment, member_id, " +
                "status,created_on, created_by)" +
                  " values  ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')"
                  , this.session, this.litre, this.price, this.total, this.date,
                  this.payment, this.member_id, this.status,  this.created_on, this.created_by)) > 0;
        }
        public bool Update()
        {
            que = new queryExecitor();
            return que.Transaction(
               string.Format(
                "Update retail set " +
                "session='{0}',litre='{1}',price='{2}',total='{3}',date='{4}',payment='{5}'," +
                "member_id = '{6}', status = '{7}', updated_by = '{8}', updated_on = '{9}' where slno='{10}'"
               , this.session, this.litre, this.price, this.total, this.date,
                  this.payment, this.member_id, this.status, this.updated_by, this.updated_on, this.slno)) > 0;
        }

        public List<RetailSale> Fetch()
        {
            que = new queryExecitor();
            return DataConvertor.ConvertDataTable<RetailSale>(
                que.NonTransaction("Select * from retail"));
        }
        public List<RetailSale> FetchJson(string date,string session)
        {
            que = new queryExecitor();
            return DataConvertor.ConvertDataTable<RetailSale>(
                que.NonTransaction("Select * from retail where date= '"+date+"' and session= '"+session +"'"));
        }

        public bool Delete(string id)
        {
            que = new queryExecitor();
            return que.Transaction(
            string.Format("delete from retail where slno='{0}'", id)) > 0;
        }

        public RetailSale Edit(int id)
        {
            que = new queryExecitor();
            List<RetailSale> result = DataConvertor
                .ConvertDataTable<RetailSale>(que
                .NonTransaction("Select * from retail where slno=" + id));

            return result.Count != 0 ? result[0] : null;
        }
    }
}