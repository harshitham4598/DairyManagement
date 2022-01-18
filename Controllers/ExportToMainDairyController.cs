using MilkDairy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilkDairy.Controllers
{
    public class ExportToMainDairyController : Controller
    {
        // GET: ExportToMainDairy
        public ActionResult ExportMainDairy()
        {  
            var milk = new ExportToMainDairy()
            {
                date = DateTime.Today,
                prices_amt = new Prices().Fetch(),
                dairys = new Society_Creation().FetchDairies(),

            };
            return View(milk); 
        }


        [HttpPost]
        public ActionResult Save(ExportToMainDairy p)
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
            ExportToMainDairy s = new ExportToMainDairy();
            return View(s.Fetch());
        }

        public ActionResult FetchJson()
        {
            ExportToMainDairy s = new ExportToMainDairy();
            return Json(new ExportToMainDairy().Fetch(), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            bool Success = false;
            ExportToMainDairy c = new ExportToMainDairy();

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
            ExportToMainDairy m = new ExportToMainDairy();
           
            m = m.Edit(id);
            m.prices_amt = new Prices().Fetch();
            m.dairys = new Society_Creation().FetchDairies();
            return View("ExportMainDairy", m);
        }





    }
}