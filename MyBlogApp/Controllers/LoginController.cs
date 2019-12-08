using MyBlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyBlogApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        readonly private CustomMembershipProvider membershipProvider = new CustomMembershipProvider();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserName,Password")] LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                if(membershipProvider.ValidateUser(loginViewModel.UserName, loginViewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(loginViewModel.UserName, false);
                    return RedirectToAction("Index", "Articles");
                }
            }
            return View(loginViewModel);
        }

        // GET: Login/SignOut
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Articles");
        }
    }
}