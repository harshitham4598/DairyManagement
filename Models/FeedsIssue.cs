using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MilkDairy.Models
{
    public class FeedsIssue
    {
        queryExecitor que;

        public decimal slno { get; set; }

        [Display(Name = "Sale Type")]
        [Required(ErrorMessage = "*")]
        public string sale_type { get; set; }

        [Display(Name = "Member ID")]
        [Required(ErrorMessage = "*")]
        public string member_id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "*")]
        public string member_name { get; set; }
        [Display(Name = "Father Name")]
        [Required(ErrorMessage = "*")]
        public string nominee_name { get; set; }

        [Display(Name = "KG")]
        [Required(ErrorMessage = "*")]
        public decimal kg { get; set; }


        [Display(Name = "Payment Mode")]
        [Required(ErrorMessage = "*")]
        public string payment_mode { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "*")]
        public decimal  price { get; set; }
        [Display(Name = "Total Amt")]
        [Required(ErrorMessage = "*")]
        public decimal total_amt { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "*")]
        public DateTime issue_date { get; set; }

        [Display(Name = "Not Member?")]
        [Required(ErrorMessage = "*")]
        public bool not_member { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        public string created_by { get; set; }
        public string updated_by { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }



        public bool Add()
        {
            que = new queryExecitor();
            return que.Transaction(string.Format("insert into feeds_issue( sale_type, member_id,member_name, nominee_name,   " +
                "kg, payment_mode, price, total_amt, " +
                "issue_date, description ,not_member , created_on, created_by)" +
                  " values  ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')"
                  , this.sale_type,this.member_id, this.member_name, this.nominee_name, this.kg,
                  this.payment_mode, this.price, this.total_amt,this.issue_date, this.description,
                  this.not_member , this.created_on, this.created_by)) > 0;
        }
        public bool Update()
        {
            que = new queryExecitor();
            return que.Transaction(
               string.Format(
                "Update feeds_issue set " +
                "sale_type='{0}',member_id='{1}',member_name='{2}',nominee_name='{3}',kg='{4}',payment_mode='{5}'," +
                "price = '{6}', total_amt = '{7}', issue_date = '{8}', description = '{9}', not_member = '{9}', updated_by = '{9}', updated_on = '{9}' where slno='{10}'"
               ,   this.sale_type,this.member_id, this.member_name, this.nominee_name, this.kg,
                  this.payment_mode, this.price, this.total_amt,this.issue_date, this.description,
                  this.not_member , this.updated_by, this.updated_on, this.slno)) > 0;
        }

        public List<FeedsIssue> Fetch()
        {
            que = new queryExecitor();
            return DataConvertor.ConvertDataTable<FeedsIssue>(
                que.NonTransaction("Select * from feeds_issue"));
        }


        public bool Delete(string id)
        {
            que = new queryExecitor();
            return que.Transaction(
            string.Format("delete from feeds_issue where slno='{0}'", id)) > 0;
        }

        public FeedsIssue Edit(int id)
        {
            que = new queryExecitor();
            List<FeedsIssue> result = DataConvertor
                .ConvertDataTable<FeedsIssue>(que
                .NonTransaction("Select * from feeds_issue where slno=" + id));

            return result.Count != 0 ? result[0] : null;
        }

    }
}