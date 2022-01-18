using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MilkDairy.Models
{
    public class AdvancePayment
    {
        queryExecitor que;

        public decimal slno { get; set; }

        [Display(Name = "Member ID")]
        [Required(ErrorMessage = "Required*")]
        public string member_id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Required*")]
        public string member_name { get; set; }
        [Display(Name = "Father Name")]
        [Required(ErrorMessage = "Required*")]
        public string nominee_name { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Required*")]
        public string address { get; set; }
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Required*")]
        public string phone_no { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Required*")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? date { get; set; }
        [Display(Name = "Adv. Amount")]
        [Required(ErrorMessage = "Required*")]
        public decimal amount { get; set; }
        public string status { get; set; }




        public string created_by { get; set; }
        public string updated_by { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }



        public bool Add()
        {
            que = new queryExecitor();
            return que.Transaction(string.Format("insert into advance_payment( member_id,member_name, nominee_name,   " +
                "address, phone_no, date, amount, " +
                "status, created_on, created_by)" +
                  " values  ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')"
                  , this.member_id, this.member_name, this.nominee_name, this.address,
                  this.phone_no, this.date, this.amount, this.status,this.created_on, this.created_by)) > 0;
        }
        public bool Update()
        {
            que = new queryExecitor();
            return que.Transaction(
               string.Format(
                "Update advance_payment set " +
                "member_id='{0}',member_name='{1}',nominee_name='{2}',address='{3}',phone_no='{4}',date='{5}'," +
                "amount = '{6}', status = '{7}' ,updated_by = '{8}', updated_on = '{9}' where slno='{10}'"
              ,this.member_id, this.member_name, this.nominee_name, this.address,
                  this.phone_no, this.date, this.amount, this.status, this.updated_by, this.updated_on, this.slno)) > 0;
        }

        public List<AdvancePayment> Fetch()
        {
            que = new queryExecitor();
            return DataConvertor.ConvertDataTable<AdvancePayment>(
                que.NonTransaction("Select * from advance_payment"));
        }


        public List<AdvancePayment> FetchJSON()
        {
            que = new queryExecitor();
            return DataConvertor.ConvertDataTable<AdvancePayment>(
                que.NonTransaction("Select * from advance_payment where status='PENDING'"));
        }

        public bool Delete(string id)
        {
            que = new queryExecitor();
            return que.Transaction(
            string.Format("delete from advance_payment where slno='{0}'", id)) > 0;
        }

        public AdvancePayment Edit(int id)
        {
            que = new queryExecitor();
            List<AdvancePayment> result = DataConvertor
                .ConvertDataTable<AdvancePayment>(que
                .NonTransaction("Select * from advance_payment where slno=" + id));

            return result.Count != 0 ? result[0] : null;
        }



    }
}