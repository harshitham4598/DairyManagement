using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MilkDairy.Models;

namespace MilkDairy.Controllers
{
    public class MemberCreationController : Controller
    {
        // GET: MemberCreation
        public ActionResult MemberCreation()
        { 
            var memb = new MemberCreation()
            {
                member_id = "MEM-" + (new MemberCreation().getSlno_Count() + 1).ToString(),  
            }; 
            return View(memb);
        }



        [HttpPost]
        public ActionResult Save(MemberCreation p)
        {
            bool Success = false;
            string Message = "";
            

            if (p.slno == 0)
            {
                p.created_on = DateTime.Now;
                p.created_by = @Session["Admin"].ToString();
                if (p.Add())
                {
                    Success = true;
                    Message = "Added Successfully";
                }
                else
                {
                    Success = false;
                    Message = "Adding failed";
                }
            }
            else
            {
                p.updated_on = DateTime.Now;
                p.updated_by = @Session["Admin"].ToString();
                if (p.Update())
                {
                    Success = true;
                    Message = "Updated Successfully";
                }
                else
                {
                    Success = false;
                    Message = "Updated failed";
                }
            }
            return Json(new { Success = Success, Message = Message });
        }



        public ActionResult Fetch()
        {
            MemberCreation s = new MemberCreation();
            return View(s.Fetch());
        }


        public ActionResult Edit(string id)
        {
            MemberCreation m = new MemberCreation();
            m = m.getIndividualMember(id);
            return View("MemberCreation", m);           

        }







    }
}