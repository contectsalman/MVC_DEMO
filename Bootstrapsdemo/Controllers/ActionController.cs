using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bootstrapsdemo;
using System.Web.Security;

namespace Bootstrapsdemo.Controllers
{
     [AllowAnonymous]
    public class ActionController : Controller
    {
        firmEntities db = new firmEntities();
        // GET: Action
       
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User u)
        {
            var count = db.Users.Where(x => x.UserName == u.UserName && x.Password == u.Password).Count();
            if (count == 0)
            {
                ViewBag.Msg = "Invalid  User";
                return RedirectToAction("Error", "Home");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                return RedirectToAction("Index","Home");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}