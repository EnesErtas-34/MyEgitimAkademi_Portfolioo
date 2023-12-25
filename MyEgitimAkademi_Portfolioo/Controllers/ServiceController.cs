using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEgitimAkademi_Portfolioo.Models;
namespace MyEgitimAkademi_Portfolioo.Controllers
{
    public class ServiceController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        [Authorize]
        public ActionResult Index()
        {
            var values = db.Service.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(Service service)
        {
            db.Service.Add(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(int id)
        {
            var value = db.Service.Find(id);
            db.Service.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = db.Service.Find(id);
            return View(value);

        }

        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var value = db.Service.Find(service.ServiceID);
            value.ServiceName = service.ServiceName;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}