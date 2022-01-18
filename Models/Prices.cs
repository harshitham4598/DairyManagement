using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MilkDairy.Models
{
    public class Prices
    {
        queryExecitor que;
        public decimal slno { get; set; }
        [Display(Name = "Price/Litre")]
        [Required(ErrorMessage = "*")]
      
        public decimal price { get; set; }

        public string created_by { get; set; }
        public string updated_by { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }

        public bool Add()
        {
            que = new queryExecitor();
            return que.Transaction(string.Format("insert into price(price,created_by,created_on)" +
                  " values  ('{0}','{1}','{2}')"
                  , this.price,  this.created_by, this.created_on)) > 0;
        }


        public bool Update()
        {
            que = new queryExecitor();
            return que.Transaction(
               string.Format(
                "Update price set " +
                "price='{0}',updated_by='{1}',updated_on='{2}' where slno='{3}'"
                , this.price, this.updated_by, this.updated_on, this.slno)) > 0;
        }



        public List<Prices> Fetch()
        {
            que = new queryExecitor();
            return DataConvertor.ConvertDataTable<Prices>(
                que.NonTransaction("Select * from price"));
        }

 
       

        public bool Delete(string id)
        {
            que = new queryExecitor();
            return que.Transaction(
            string.Format("delete from price where slno='{0}'", id)) > 0;
        }

        public Prices Edit(int id)
        {
            que = new queryExecitor();
            List<Prices> result = DataConvertor
                .ConvertDataTable<Prices>(que
                .NonTransaction("Select * from price where slno=" + id));

            return result.Count != 0 ? result[0] : null;
        }
    }
}