using MilkDairy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilkDairy.Controllers
{
    public class AdminCreationController : Controller
    {
        // GET: AdminCreation
        public ActionResult AdminCreation()
        {
            AdminLogin a = new AdminLogin();
            return View(a);
        }

        [HttpPost]
        public ActionResult Save(AdminLogin p)
        {
            bool Success = false;
            string Message = "";
            p.created_by = Session["Admin"].ToString();
            if (p.slno == 0)
            {
                p.created_on = DateTime.Now;
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
            AdminLogin s = new AdminLogin();
            return Json(new AdminLogin().FetchSociety(), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            bool Success = false;
            AdminLogin c = new AdminLogin();

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
            AdminLogin m = new AdminLogin();
            m = m.Edit(id);
            return View("AdminCreation", m);
        }
    }
}