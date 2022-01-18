using MilkDairy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilkDairy.Controllers
{
    public class SocietyCreationController : Controller
    {
        // GET: SocietyCreation
        public ActionResult SocietyCreation()
        {
            Society_Creation so = new Society_Creation();
            so.istrue = new Society_Creation().getValidate();   
            return View(so);
        }


        [HttpPost]
        public ActionResult Save(Society_Creation p)
        {
            bool Success = false;
            string Message = "";

            if (p.slno == 0)
            { 

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
            Society_Creation s = new Society_Creation();
            return Json(new Society_Creation().FetchSociety(), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            bool Success = false;
            Society_Creation c = new Society_Creation();

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

        public ActionResult Edit(int id)
        {
            Society_Creation m = new Society_Creation();
            m = m.Edit(id);
            return View("SocietyCreation", m);
        }
    }
}