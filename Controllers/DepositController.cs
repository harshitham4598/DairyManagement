using MilkDairy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilkDairy.Controllers
{
    public class DepositController : Controller
    {
        // GET: Deposit
        public ActionResult DepositeCreate()
        {
            Deposit d = new Deposit(); 
            return View(d);
        }

        [HttpPost]
        public ActionResult Save(Deposit p)
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
            Deposit s = new Deposit();
            return Json(new Deposit().Fetch(), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            bool Success = false;
            Deposit c = new Deposit();

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
            Deposit m = new Deposit();
            m = m.Edit(id);
            return View("DepositeCreate", m);
        }
    }
}