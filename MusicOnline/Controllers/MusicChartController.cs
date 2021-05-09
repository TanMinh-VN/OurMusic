using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicOnline.Controllers
{
    public class MusicChartController : Controller
    {
        // GET: MusicChart
        public ActionResult Index()
        {
            ViewBag.ListVN = MusicDAO.Instance.getVietNamSongChart();
            ViewBag.ListUSUK = MusicDAO.Instance.getUSUKSongChart();
            ViewBag.ListKpop = MusicDAO.Instance.getKpopSongChart();
            return View();
        }
    }
}