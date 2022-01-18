using MilkDairy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilkDairy.Controllers
{
    public class AdvancePaymentController : Controller
    {
        // GET: AdvancePayment
        public ActionResult AdvancePaymentCreate()
        {
            AdvancePayment a = new AdvancePayment();
            return View(a);
        }

        [HttpPost]
        public ActionResult Save(AdvancePayment p)
        {
            bool Success = false;
            string Message = "";
            //  p.created_by = Session["Admin"].ToString();
            if (p.slno == 0)
            {
                p.created_on = DateTime.Now;
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
            AdvancePayment s = new AdvancePayment();
            return View(s.Fetch());
        }



        public ActionResult FetchJson()
        {
            AdvancePayment s = new AdvancePayment();
            return Json(new AdvancePayment().FetchJSON(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            bool Success = false;
            AdvancePayment c = new AdvancePayment();

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
            AdvancePayment m = new AdvancePayment();
            m = m.Edit(id);
            return View("AdvancePaymentCreate", m);
        }

    }
}