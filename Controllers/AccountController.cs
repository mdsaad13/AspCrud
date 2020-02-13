using AspCrud.DAL;
using AspCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspCrud.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        //Post method of Login
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(UserInfo User)
        {
            /*
             * Creating object of DAL class Account
             */
            Account db = new Account();

            /*
             * Creating object of Model class UserInfo
             */
            UserInfo result = new UserInfo();

            /*
             * Passing parameters to Login method of Account class
             * @param Email (Which we are fetching from UserInfo Modal)
             * @param Passwd (Which we are fetching from UserInfo Modal)
             * 
             * @return object
             */
            result = db.Login(User.Email, User.Passwd);

            if (result.ID != 0)
            {
                /*
                 * if user exist then set Session and redirect to Home page
                 */
                Session["UserID"] = result.ID;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                /*
                 * if user does not exist then display error message
                 */
                ViewData["Error"] = @"
                    <div class=""alert alert-danger wow shake"" role=""alert"" data-wow-delay=""1s"">
                      Incorrect Email or Password!
                    </div>
                ";
                return View();
            }

        }

        public ActionResult Register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(UserInfo user)
        {
            /*
             * Creating object of DAL class Account
             */
            Account db = new Account();

            /*
             * @param UserInfo modal class to CreateAccount method of Account class
             * @return number of rows affected
             */
            int rows = db.CreateAccount(user);
            if (rows > 0)
            {
                /*
                 * if insert success
                 */
                return RedirectToAction("Login", "Account");
            }
            else
            {
                /*
                 * if insert failure
                 */
                ViewData["Error"] = @"
                    <div class=""alert alert-danger"" role=""alert"">
                      Unknown error occured!
                    </div>
                ";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
