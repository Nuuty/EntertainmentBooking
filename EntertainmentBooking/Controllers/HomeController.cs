using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntertainmentBooking.Models;

namespace EntertainmentBooking.Controllers
{
    public class HomeController : Controller
    {
        public EntertainmentDbContext DbContext { get; set; }

        public HomeController()
        {
            DbContext = new EntertainmentDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Arrangements()
        {
            var models = DbContext.arrangements.Include(b => b.bands).ToList();
            return View(models);
        }

        public ActionResult Genres()
        {
            var models = DbContext.genres.Include(b => b.bands).ToList();
            return View(models);
        }
    }
}