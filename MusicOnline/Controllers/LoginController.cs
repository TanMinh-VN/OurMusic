using MusicOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;
using MusicOnline.Code;
using System.Web.Security;

namespace MusicOnline.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var result = AccountDAO.Instance.VerifyAccount(login.userName, login.password);
                if (result)
                {
                    ////SessionHelper.SetSession(new UserSession() { UserName = login.userName });
                    //FormsAuthentication.SetAuthCookie(login.userName, login.rememberMe);
                    //return RedirectToAction("Index", "Home");
                    var user = AccountDAO.Instance.GetAccountByUsername(login.userName);
                    UserSession userSession = new UserSession() {AccountID=user.accountID ,UserName = user.username,FullName=user.fullname };
                    Session.Add(SessionConstants.USER_SESSION,userSession);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu");
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Remove(SessionConstants.USER_SESSION);
            return RedirectToAction("Login", "Login");
        }
    }
}