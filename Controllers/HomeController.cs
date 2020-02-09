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
            /*
             * Creating object of DAL class `HomeDbUtil`
             */
            HomeDbUtil dbObj = new HomeDbUtil();

            /*
             * List class of type `StudentDetails` model
             * List is a dynamic generic collection array 
             */
            List<StudentDetails> details = new List<StudentDetails>();
            details = dbObj.GetAllStudents();
            return View(details);
        }

        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(StudentDetails std)
        {
            /*
             * Creating object of DAL class `HomeDbUtil`
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
        }

        public ActionResult UpdateStudent(int stdId)
        {
            return View();
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