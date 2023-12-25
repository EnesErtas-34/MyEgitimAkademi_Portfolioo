using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEgitimAkademi_Portfolioo.Models;

namespace MyEgitimAkademi_Portfolioo.Controllers
{
    public class DefaultController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialQuickContack()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            var values = db.About.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialService()
        {
            var values = db.Service.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSkill()
        {
            var values = db.Skill.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAward()
        {
            var values = db.Award.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = db.Testimonial.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialClient()
        {
            ViewBag.projectCount = db.Project.Count();
            ViewBag.testimonialCount = db.Testimonial.Count();
            ViewBag.award = db.Award.Count();
            return PartialView();
        }
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
    }
}