using MilkDairy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilkDairy.Controllers
{
    public class RetailController : Controller
    {
        // GET: Retail
        public ActionResult Retail()
        {
            var milk = new RetailSale()
            {
                date = DateTime.Today,
                prices_amt = new Prices().Fetch(),
            };
            return View(milk);          
        }

        [HttpPost]
        public ActionResult Save(RetailSale p)
        {
            bool Success = false;
            string Message = "";
            //  p.created_by = Session["Admin"].ToString();
            if (p.slno == 0)
            {
                p.created_on = DateTime.Now;
                if(p.member_id!=null)
                {
                    p.status = "PENDING";
                }

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
            RetailSale s = new RetailSale();
            return View();
        }



        public ActionResult FetchJson(string date,string session)
        {
            RetailSale s = new RetailSale();
            return Json(new RetailSale().FetchJson(date, session), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            bool Success = false;
            RetailSale c = new RetailSale();

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
            RetailSale m = new RetailSale();
            m = m.Edit(id);
            m.prices_amt = new Prices().Fetch();
            return View("Retail", m);
        }









    }
}