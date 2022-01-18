using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MilkDairy.Models
{
    public class Deposit
    {
        queryExecitor que;
        public decimal slno { get; set; }

        [Display(Name = "Deposit Amt.")]
        [Required(ErrorMessage = "*")]
        public decimal deposit_amt { get; set; }

        [Display(Name = "Account Type")]
        [Required(ErrorMessage = "*")]
        public string acc_type { get; set; }

        [Display(Name = " Total Amt.")]
        [Required(ErrorMessage = "*")]
        public decimal total_amt { get; set; }

        [Display(Name = " Current Bal.")]
        [Required(ErrorMessage = "*")]
        public decimal current_bal { get; set; }

        [Display(Name = "Narration")]
        [Required(ErrorMessage = "*")]
        public string narraton { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "*")]
        public DateTime date { get; set; }


        public string created_by { get; set; }
        public string updated_by { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }

        public bool Add()
        {
            que = new queryExecitor();
            return que.Transaction(string.Format("insert into deposit(deposit_amt,acc_type,total_amt,current_bal,narraton,date,created_by,created_on)" +
                  " values  ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')"
                  , this.deposit_amt, this.acc_type, this.total_amt, this.current_bal, this.narraton, this.date, this.created_by, this.created_on)) > 0;
        }


        public bool Update()
        {
            que = new queryExecitor();
            return que.Transaction(
               string.Format(
                "Update deposit set " +
                "price='{0}',updated_by='{1}',updated_on='{2}' where slno='{3}'"
                , this.deposit_amt, this.updated_by, this.updated_on, this.slno)) > 0;
        }



        public List<Deposit> Fetch()
        {
            que = new queryExecitor();
            return DataConvertor.ConvertDataTable<Deposit>(
                que.NonTransaction("Select * from deposit"));
        }




        public bool Delete(string id)
        {
            que = new queryExecitor();
            return que.Transaction(
            string.Format("delete from deposit where slno='{0}'", id)) > 0;
        }

        public Deposit Edit(int id)
        {
            que = new queryExecitor();
            List<Deposit> result = DataConvertor
                .ConvertDataTable<Deposit>(que
                .NonTransaction("Select * from deposit where slno=" + id));

            return result.Count != 0 ? result[0] : null;
        }
    }
}