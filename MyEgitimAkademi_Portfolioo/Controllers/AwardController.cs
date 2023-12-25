using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEgitimAkademi_Portfolioo.Models;

namespace MyEgitimAkademi_Portfolioo.Controllers
{
    public class AwardController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.Award.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAward()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAward(Award award)
        {
            db.Award.Add(award);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAward(int id)
        {
            var values = db.Award.Find(id);
            db.Award.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAward(int id)
        {
            var value = db.Award.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAward(Award award)
        {
            var values = db.Award.Find(award.AwardID);
            values.Title = award.Title;
            values.Description = award.Description;
            values.ImageUrl = award.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}