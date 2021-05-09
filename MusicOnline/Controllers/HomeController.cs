using DAO;
using MusicOnline.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ListArtist = ArtistDAO.Instance.getListArtist();
            ViewBag.ListSong = MusicDAO.Instance.getListMusic();
            return View();
        }

      
    }
}