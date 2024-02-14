using MyBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyBooks.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        [AllowAnonymous]
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Shop model)
        {
            using (var context = new BookEntities())
            {
                bool IsValid = context.UserTables.Any(x => x.Username == model.Username && x.Password == model.Password && x.UserType == "Shopkeeper");
                
                if (IsValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("Index", "Books");
                }
                bool isCusto = context.UserTables.Any(x => x.Username == model.Username && x.Password == model.Password && x.UserType == "Customer");
                if (isCusto)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("Customer", "Books1");
                }
                ModelState.AddModelError("", "Invalid Username ANd Password");
                return View();

            }
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(UserTable model)
        {
            using (var context = new BookEntities())
            {
                context.UserTables.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}