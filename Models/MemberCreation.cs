using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MilkDairy.Models
{
    public class MemberCreation
    {
        queryExecitor que;
        public decimal slno { get; set; }
        [Display(Name = "Member ID")]
        [Required(ErrorMessage = "*")]
        public string member_id { get; set; }
        [Display(Name = "Member Name")]
        [Required(ErrorMessage = "*")]
        public string member_name { get; set; }
        [Display(Name = "Father Name")]
        [Required(ErrorMessage = "*")]
        public string nominee_name { get; set; }
        [Display(Name = "DOB")]
     //   [Required(ErrorMessage = "*")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? dob { get; set; }
        [Display(Name = "Pan Card")]
       // [Required(ErrorMessage = "*")]
        public string pan_card { get; set; }
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "*")]
        public string gender { get; set; }
         [MaxLength(10, ErrorMessage = "Maximum 10 Number Allowed")]
        [Display(Name = "Phone No")]
        [Required(ErrorMessage = "*")]
        public string phone_no { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "*")]
        public string address { get; set; }
        [Display(Name = " Bank Name")]
        [Required(ErrorMessage = "*")]
        public string bank_name { get; set; }
        [Display(Name = "Acc No")]
        [Required(ErrorMessage = "*")]
        public string acc_no { get; set; }
        [Display(Name = "IFSC")]
        [Required(ErrorMessage = "*")]
        public string ifsc { get; set; }
        [Display(Name = "Adhar No")]
        [Required(ErrorMessage = "*")]
        [MaxLength(12, ErrorMessage = "Maximum 12 Number Allowed")]
        public string adhar_no { get; set; }
        [Display(Name = "Branch")]
        [Required(ErrorMessage = "*")]
        public string branch { get; set; }

        public string created_by { get; set; }
        public string updated_by { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }


        public int getSlno_Count()
        {
            que = new queryExecitor();
            return Convert.ToInt32(
                que.Aggregate("Select case when MAX(slno) is null then 0 else max(slno) end  from member_master"));
        }

        public bool Add()
        {
            que = new queryExecitor();
            return que.Transaction(string.Format("insert into member_master( member_id, member_name, nominee_name, dob, pan_card, "+
                "gender, phone_no, address, bank_name, acc_no, "+
                "ifsc, adhar_no,branch, created_on, created_by )" +
                  " values  ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')"
                  , this.member_id, this.member_name, this.nominee_name, this.dob, this.pan_card, this.gender, this.phone_no,this.address,
                  this.bank_name,this.acc_no,this.ifsc,this.adhar_no,this.branch,this.created_on
                  ,this.created_by)) > 0;
        }


        public bool Update()
        {
            que = new queryExecitor();
            return que.Transaction(
               string.Format(
                "Update member_master set " +
                "updated_by='{0}',member_name='{1}',nominee_name='{2}',dob='{3}',pan_card='{4}',gender='{5}'," +
                "phone_no = '{6}', address = '{7}', bank_name = '{8}', acc_no = '{9}'," +
                "ifsc = '{10}',adhar_no = '{11}',updated_on = '{12}',branch = '{13}' where member_id='{14}'"
                , this.updated_by, this.member_name, this.nominee_name, this.dob, this.pan_card,
                this.gender, this.phone_no,this.address,this.bank_name,this.acc_no,this.ifsc,this.adhar_no,this.updated_on,this.branch,this.member_id)) > 0;
        }

        public List<MemberCreation> Fetch()
        {
            que = new queryExecitor();
            return DataConvertor.ConvertDataTable<MemberCreation>(
                que.NonTransaction("Select * from member_master"));
        }

       

        public MemberCreation getIndividualMember(string id)
        {
            que = new queryExecitor();
            List<MemberCreation> result = DataConvertor
                .ConvertDataTable<MemberCreation>(que
                .NonTransaction("Select * from member_master where member_id='" + id +"'"));
            return result.Count != 0 ? result[0] : null;
        }

    }
}