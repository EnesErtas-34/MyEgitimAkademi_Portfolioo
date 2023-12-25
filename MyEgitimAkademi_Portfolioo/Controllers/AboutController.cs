using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEgitimAkademi_Portfolioo.Models;
namespace MyEgitimAkademi_Portfolioo.Controllers
{
    public class AboutController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.About.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            var values = db.About.Add(about);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteAbout(int id)
        {
            var values = db.About.Find(id);
            db.About.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = db.About.Find(id);
            return View(values);
        }

        [HttpPost]

        public ActionResult UpdateAbout(About about)
        {
            var values = db.About.Find(about.AboutID);
            values.NameSurname = about.NameSurname;
            values.Introduction = about.Introduction;
            values.AboutImage = about.AboutImage;
            values.Description = about.Description;
            values.Title = about.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}