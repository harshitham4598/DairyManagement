using MilkDairy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilkDairy.Controllers
{
    public class PriceController : Controller
    {
        // GET: Price
        public ActionResult PriceCreation()
        {
            Prices p = new Prices();
            return View(p);
        }


        public ActionResult PriceCreations()
        {
            Prices p = new Prices();
            return View(p);
        }

        [HttpPost]
        public ActionResult Save(Prices p)
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
            Prices s = new Prices();
            return Json(new Prices().Fetch(), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            bool Success = false;
            Prices c = new Prices();

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
            Prices m = new Prices();
            m = m.Edit(id);
            return View("PriceCreation", m);
        }

    }
}