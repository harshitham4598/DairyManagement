using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MilkDairy.Models;

namespace MilkDairy.Controllers
{
    public class FeedsIssueController : Controller
    {
        // GET: FeedsIssue
        public ActionResult FeedsIssue()
        {
            FeedsIssue feed = new FeedsIssue();
            return View(feed);
        }


        [HttpPost]
        public ActionResult Save(FeedsIssue p)
        {
            bool Success = false;
            string Message = "";
            //  p.created_by = Session["Admin"].ToString();
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
            FeedsIssue s = new FeedsIssue();
            return View(s.Fetch());
        }



        public ActionResult FetchJson()
        {
            FeedsIssue s = new FeedsIssue();
            return Json(new FeedsIssue().Fetch(), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            bool Success = false;
            FeedsIssue c = new FeedsIssue();

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
            FeedsIssue m = new FeedsIssue();
            m = m.Edit(id);
            return View("FeedsIssue", m);
        }


       

    }
}