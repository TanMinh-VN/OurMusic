using DAO;
using MusicOnlineDB.Self_Created;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicOnline.Code;

namespace MusicOnline.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Personal
        public ActionResult Index()
        {
            UserSession session = Session[SessionConstants.USER_SESSION] as UserSession;
            PersonalModel personal = PersonalDAO.Instance.LoadPersonalPage(session.AccountID);
            return View(personal);
        }
        [HttpPost]
        public JsonResult AddFavouriteSong(FormCollection data)
        {
            int accountID = Convert.ToInt32(data["accountID"]);
            int songID = Convert.ToInt32(data["songid"]);
            JsonResult js = new JsonResult();
            PersonalDAO.Instance.AddFavouriteSong(accountID, songID);
            js.Data = new { status = "OK" };
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddFavouriteArtist(FormCollection data)
        {
            int accountID = Convert.ToInt32(data["accountID"]);
            int artistID = Convert.ToInt32(data["artistID"]);
            JsonResult js = new JsonResult();
            PersonalDAO.Instance.AddFavouriteArtist(accountID, artistID);
            js.Data = new { status = "OK" };
            return Json(js, JsonRequestBehavior.AllowGet);
        }

    }
}