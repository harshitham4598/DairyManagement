using MilkDairy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilkDairy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var g = new Society_Creation();
            g = g.getInfo();
            return View("Index", g);           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public ActionResult LoginVerify(AdminLogin c)
        {
            try
            {
                bool Success = false;
                string Message = "";
                string usertype = "";

                if (c.userLogincheck())
                {
                    var user = new AdminLogin().getuser(c.user_name.ToLower());
                    usertype = user.user_type;
                    if (usertype == "Admin")
                    {
                        Session["Admin"] = user.user_name.ToString();    
                        if(DateTime.Now.ToString("tt")=="PM")
                        {
                            Session["Time"] = "Evening"; 
                        }
                        else if(DateTime.Now.ToString("tt")=="AM")
                        {
                            Session["Time"] = "Morning";
                        }
                    }
                    else
                    {
                        //Session["Employee"] = user.fullname.ToString();
                        //Session["Employeeslno"] = user.slno;
                    }
                    Success = true;
                    Message = "Login Successfully";
                }

                else
                {
                    Success = false;
                    Message = "Username or Password Incorrect..";

                }
                return Json(new { Success = Success, Message = Message, userType = usertype });

            }
            catch
            {
                return Json(new { Success = false, Message = "Operation Failed" });
            }
        }

    }
}