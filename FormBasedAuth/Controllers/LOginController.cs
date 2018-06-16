using FormBasedAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormBasedAuth.Controllers
{
    public class LoginController : Controller
    {
        List<User> userList = new List<User>()
        {
            new Models.User(){UserId = "01", Password = "01", Name="Sam"}

        };

        // GET: Login
        public ActionResult Index(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorization(FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                string userid = Request.Form["txtuserid"];
                if ((frm["txtuserid"] == "01") && (frm["txtPassword"] == "01"))
                {
                    FormsAuthentication.SetAuthCookie(frm["txtuserid"], false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Index");
                }
            }
            return View("Index","Login");

        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}