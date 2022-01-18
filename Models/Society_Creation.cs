using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MilkDairy.Models
{
    public class Society_Creation
    {
        queryExecitor que;


        public decimal slno { get; set; }
        [Display(Name = "Dairy Name")]
        [Required(ErrorMessage = "*")]
        public string society_name { get; set; }

        [Display(Name = "Village")]
        [Required(ErrorMessage = "*")]
        public string village { get; set; }

        [Display(Name = "Taluk")]
        [Required(ErrorMessage = "*")]
        public string taluk { get; set; }

        [Display(Name = "District")]
        [Required(ErrorMessage = "*")]
        public string district { get; set; }

        [Display(Name = "Pincode")]
        [Required(ErrorMessage = "*")]
        public string pincode { get; set; }

        [Display(Name = "Phone No.")]
        [Required(ErrorMessage = "*")]
        public string phone_no { get; set; }

        public DateTime created_on = DateTime.Now;

        [Display(Name = "My Dairy")]
        public Boolean mydairy { get; set; }

        public int istrue { get; set; }


        public bool Add()
        {
            que = new queryExecitor();
            return que.Transaction(string.Format("insert into society_creation(society_name,village,taluk,district,pincode,phone_no,created_on,mydairy)" +
                  " values  ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')"
                  , this.society_name, this.village, this.taluk, this.district, this.pincode, this.phone_no, this.created_on, this.mydairy)) > 0;
        }


        public bool Update()
        {
            que = new queryExecitor();
            return que.Transaction(
               string.Format(
                "Update society_creation set " +
                "society_name='{0}',village='{1}',taluk='{2}',district='{3}',pincode='{4}',phone_no='{5}',mydairy='{6}' where slno='{7}'"
                ,  this.society_name, this.village, this.taluk, this.district, this.pincode, this.phone_no,this.mydairy ,this.slno)) > 0;
        }


        public List<Society_Creation> FetchSociety()
        {
            que = new queryExecitor();
            return DataConvertor.ConvertDataTable<Society_Creation>(
                que.NonTransaction("Select * from society_creation"));
        }

        public List<Society_Creation> FetchDairies()
        {
            que = new queryExecitor();
            return DataConvertor.ConvertDataTable<Society_Creation>(
                que.NonTransaction("Select * from society_creation where mydairy=false"));
        }

        public bool Delete(string id)
        {
            que = new queryExecitor();
            return que.Transaction(
            string.Format("delete from society_creation where slno='{0}'", id)) > 0;
        }

        public Society_Creation Edit(int id)
        {
            que = new queryExecitor();
            List<Society_Creation> result = DataConvertor
                .ConvertDataTable<Society_Creation>(que
                .NonTransaction("Select * from society_creation where slno=" + id));

            return result.Count != 0 ? result[0] : null;
        }


        public Society_Creation getInfo()
        {
            que = new queryExecitor();
            return DataConvertor.ConvertDataTable<Society_Creation>(que.NonTransaction((string.Format("select * from society_creation where mydairy=true"))))[0];
        }

        public int getValidate()
        {
            que = new queryExecitor();
            return Convert.ToInt32(
                que.Aggregate("select count(society_name) from society_creation where mydairy=true"));
        }
       
    }
}