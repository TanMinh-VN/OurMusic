using DAO;
using MusicOnlineDB.EF;
using MusicOnlineDB.Self_Created;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicOnline.Controllers
{
    public class MVController : Controller
    {
        // GET: MV
        public ActionResult Index()
        {
            IEnumerable<SongModel> model = MusicDAO.Instance.getListMV();
            ViewBag.ListUSUK = MusicDAO.Instance.getListUsUkMV();
            ViewBag.ListKpopMV = MusicDAO.Instance.getListKpopMV();
            return View(model);
        }
        public ActionResult PlayingMV(int id)
        {
            SongModel mv = MusicDAO.Instance.getMVByID(id);
            ViewBag.MV = mv;
            ViewBag.ListSimilarMV = MusicDAO.Instance.getListSimilarMV(mv.genreName);
            return View();
        }
    }
}