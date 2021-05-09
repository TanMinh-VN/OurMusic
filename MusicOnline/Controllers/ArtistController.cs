using DAO;
using MusicOnlineDB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicOnline.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int artistID)
        {
            Artist model = ArtistDAO.Instance.getArtistByID(artistID);
            ViewBag.ListArtistSong = MusicDAO.Instance.getListSongByArtistID(artistID);
            return View(model);
        }
    }
}