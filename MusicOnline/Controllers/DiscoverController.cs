using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicOnline.Controllers
{
    public class DiscoverController : Controller
    {
        // GET: Discover
        public ActionResult Index()
        {
            ViewBag.ListNation = ArtistDAO.Instance.getListNation();
            ViewBag.ListGenre = GenreDAO.Instance.getListGenre();
            ViewBag.ListTag = TagDAO.Instance.getListTag();
            ViewBag.ListWannaSong = MusicDAO.Instance.getListWannaSong();
            return View();
        }
    }
}