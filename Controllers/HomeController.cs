using AspCrud.DAL;
using AspCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspCrud.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(StudentDetails std)
        {
            /*
             * Creating object of DAL class HomeDbUtil
             */
            HomeDbUtil db = new HomeDbUtil();

            /*
             * @param StudentDetails modal class to CreateAccount method of Account class
             * @return number of rows affected
             */
            int rows = db.CreateStudent(std);
            if (rows > 0)
            {
                /*
                 * if insert success
                 */
                Session["Notification"] = 1;
                return RedirectToAction("Index");
            }
            else
            {
                /*
                 * if insert failure
                 */
                Session["Notification"] = 2;
                return RedirectToAction("Index");
            }

            //ViewBag.Message = "Your contact page.";
        }

        public ActionResult About()
        {
            //ViewBag.Message = "About from ViewBag";
            //ViewData["Error"] = "About from ViewData";
            //return View("Contact");
            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}