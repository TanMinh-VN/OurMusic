using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicOnline.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(FormCollection form)
        {
            string keyword = form["keyword"].ToString();
            ViewBag.SearchSong = MusicDAO.Instance.searchSong(keyword);
            ViewBag.SearchArtist = ArtistDAO.Instance.searchArtist(keyword);
            ViewBag.SearchMV = MusicDAO.Instance.searchMV(keyword);
            return View();
        }
    }
}