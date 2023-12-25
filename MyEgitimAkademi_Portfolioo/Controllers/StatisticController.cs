using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEgitimAkademi_Portfolioo.Models;

namespace MyEgitimAkademi_Portfolioo.Controllers
{
    public class StatisticController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            ViewBag.totalProjectCount = db.Project.Count();
            ViewBag.totalTestimonialCount = db.Testimonial.Count();
            ViewBag.sumWorkDay = db.Project.Sum(x => x.CompleteDay);
            ViewBag.avgWorkDay = db.Project.Average(x => x.CompleteDay);
            ViewBag.avgPrice = db.Project.Average(x => x.Price);
            var value = db.Project.Max(x => x.Price);
            ViewBag.maxPriceProject = db.Project.Where(x => x.Price == value).Select(y => y.Title).FirstOrDefault();
            //var value2 = db.Category.Where(x => x.CategoryName == "AspNet Core Web Geliştirme").Select(y => y.CategoryID).FirstOrDefault();
            ViewBag.categoryCountByName = db.Project.Where(x => x.ProjectCategory == db.Category.Where(y => y.CategoryName == "AspNet Core Web Geliştirme").Select(z => z.CategoryID).FirstOrDefault()).Count();
            return View();
        }
    }
}