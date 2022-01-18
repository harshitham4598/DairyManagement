using MilkDairy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilkDairy.Controllers
{
    public class MilkAquirementController : Controller
    {
        // GET: MilkAquirement
        public ActionResult MilkAquirement()
        { 
            var milk = new MilkAquirements()
            {
                date = DateTime.Today,
                prices_amt = new Prices().Fetch(),               

            };
            return View(milk); 

        }

        [HttpPost]
        public ActionResult Save(MilkAquirements p)
        {
            bool Success = false;
            string Message = "";


            if (p.slno == 0)
            {
                p.created_on = DateTime.Now;
               // p.created_by = @Session["Admin"].ToString();
                p.status = "PENDING";
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
                //p.updated_on = DateTime.Now;
                //p.updated_by = @Session["Admin"].ToString();
                //if (p.Update())
                //{
                //    Success = true;
                //    Message = "Updated Successfully";
                //}
                //else
                //{
                //    Success = false;
                //    Message = "Updated failed";
                //}
            }
            return Json(new { Success = Success, Message = Message });
        }



        public ActionResult Fetch()
        {
            MilkAquirements s = new MilkAquirements();
            return View(s.Fetch());
        }

        public ActionResult FetchJson()
        {
            MilkAquirements s = new MilkAquirements();
            return Json(new MilkAquirements().FetchTodaysList(), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            bool Success = false;
            MilkAquirements c = new MilkAquirements();

            if (c.Delete(id))
            {
                Success = true;
            }
            else
            {
                Success = false;
            }
            return Json(new { Success = Success });
        }

        public ActionResult Edit(string id)
        {
            MilkAquirements m = new MilkAquirements();                  
            m = m.getIndividualMilkAquirement(id);
            m.prices_amt = new Prices().Fetch(); 
            return View("MilkAquirement", m);
        }



        [HttpPost]
        public ActionResult MemberSearch(string query)
        {
            MemberCreation menu = new MemberCreation();
            List<MemberCreation> MenuList = menu.Fetch();
            if (!String.IsNullOrWhiteSpace(query))
                MenuList = MenuList.Where(m => m.member_id.ToLower().Contains(query)).ToList();

            return Json(MenuList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult MemberSearchName(string query)
        {
            MemberCreation menu = new MemberCreation();
            List<MemberCreation> MenuList = menu.Fetch();
            if (!String.IsNullOrWhiteSpace(query))
                MenuList = MenuList.Where(m => m.member_name.ToLower().Contains(query)).ToList();

            return Json(MenuList, JsonRequestBehavior.AllowGet);
        }

    }
}