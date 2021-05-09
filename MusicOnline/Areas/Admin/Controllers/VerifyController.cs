using MusicOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MusicOnline.Areas.Admin.Controllers
{
    public class VerifyController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel login)
        {
            //AccountDAO acc = new AccountDAO();
            //var result = acc.VerifyAccount(login.userName, login.password);
            if (Membership.ValidateUser(login.userName, login.password) && ModelState.IsValid)
            {
                //SessionHelper.SetSession(new UserSession() { UserName = login.userName });
                FormsAuthentication.SetAuthCookie(login.userName, login.rememberMe);
                return RedirectToAction("Index", "DashBoard");
            }
            else
            {
                ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu");
            }
            return View();
        }
    }
}