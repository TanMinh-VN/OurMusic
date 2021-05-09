using DAO;
using MusicOnline.Models;
using MusicOnlineDB.Self_Created;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;

namespace MusicOnline.Controllers
{
    public class MusicController : Controller
    {
        // GET: Music
        public ActionResult HotMusic(int page = 1,int pageSize=20)
        {
            IEnumerable<SongModel> l = MusicDAO.Instance.getListMusic(page,pageSize);

            return View(l);
            
        }

        public ActionResult Nation(int page, int pageSize,string nation)
        {
            IEnumerable<SongModel> l = MusicDAO.Instance.getListMusicByNation(page,pageSize,nation);
            return View(l);
        }
        public ActionResult Genre(int page, int pageSize, int genreID)
        {
            IEnumerable<SongModel> l = MusicDAO.Instance.getListMusicByGenreID(page, pageSize, genreID);
            return View(l);
        }

        public ActionResult Tag(int page, int pageSize, int tagID)
        {
            IEnumerable<SongModel> l = MusicDAO.Instance.getListMusicByTagID(page,pageSize,tagID);
            return View(l);
        }

        public FileResult DownloadFile(string songUrl )
        {
            //string fullpath = "../Content/music-files/BuiAnhTuan/NoiTinhYeuBatDau-BuiAnhTuan-1915267.mp3";
            string path = Server.MapPath("~/Content/music-files/");
            string fileName = Path.GetFileName(songUrl);
            string fullPath = Path.Combine(path, fileName);
            return File(fullPath,"music/mp3",fileName);

        }

        public ActionResult PlayingSong(int songID)
        {
            SongModel model = new SongModel();
            model = MusicDAO.Instance.getSongByID(songID);
            ViewBag.ListSimilarSong = MusicDAO.Instance.getListSimilarSong(model.genreName);

            return View(model);
        }

    }
}