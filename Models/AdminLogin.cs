using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MilkDairy.Models
{
    public class AdminLogin
    {
        queryExecitor que;

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "*")]
        public string user_name { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "*")]
        public string password { get; set; }
        [Display(Name = "User Type")]
        [Required(ErrorMessage = "*")]
        public string user_type { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "*")]

        public string name { get; set; }
        public decimal slno { get; set; }        

        public DateTime updated_on { get; set; }        
        public DateTime created_on { get; set; }         
        public string created_by { get; set; }

        public bool userLogincheck()
        {
            que = new queryExecitor();
            return que.Aggregate(string.Format("select count(*) from user_register where user_name='{0}' and password='{1}' and (user_type='Admin')", this.user_name, this.password)) > 0;
        }


        public AdminLogin getuser(string user_name)
        {
            que = new queryExecitor();
            return DataConvertor.ConvertDataTable<AdminLogin>(que.NonTransaction(string.Format("select * from user_register where user_name='{0}'", user_name)))[0];
        }



        public bool Add()
        {
            que = new queryExecitor();
            return que.Transaction(string.Format("insert into user_register(user_name,password,user_type,name,created_on)" +
                  " values  ('{0}','{1}','{2}','{3}','{4}')"
                  , this.user_name, this.password, this.user_type, this.name,this.created_on)) > 0;
        }


        public bool Update()
        {
            que = new queryExecitor();
            return que.Transaction(
               string.Format(
                "Update user_register set " +
                "user_name='{0}',password='{1}',user_type='{2}',name='{3}',updated_on='{4}' where slno='{5}'"
                , this.user_name, this.password, this.user_type, this.name, this.updated_on , this.slno)) > 0;
        }


        public List<AdminLogin> FetchSociety()
        {
            que = new queryExecitor();
            return DataConvertor.ConvertDataTable<AdminLogin>(
                que.NonTransaction("Select * from user_register"));
        }

        public bool Delete(string id)
        {
            que = new queryExecitor();
            return que.Transaction(
            string.Format("delete from user_register where slno='{0}'", id)) > 0;
        }

        public AdminLogin Edit(int id)
        {
            que = new queryExecitor();
            List<AdminLogin> result = DataConvertor
                .ConvertDataTable<AdminLogin>(que
                .NonTransaction("Select * from user_register where slno=" + id));

            return result.Count != 0 ? result[0] : null;
        }


        public AdminLogin getInfo()
        {
            que = new queryExecitor();
            return DataConvertor.ConvertDataTable<AdminLogin>(que.NonTransaction((string.Format("select * from user_register"))))[0];
        }
       




    }
}