using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Runtime.Caching;
using VidlyAppWithLatestAuth.Models;

namespace VidlyAppWithLatestAuth.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            if(MemoryCache.Default["Genres"] == null)
            {
                MemoryCache.Default["Genres"] = _context.Genres.ToList();
            }

            var gebres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}