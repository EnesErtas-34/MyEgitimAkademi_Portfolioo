using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEgitimAkademi_Portfolioo.Models;
namespace MyEgitimAkademi_Portfolioo.Controllers
{
    public class ContactController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.description = db.Address.Select(x => x.Description).FirstOrDefault();
            ViewBag.phone = db.Address.Select(x => x.Phone).FirstOrDefault();
            ViewBag.adressdetail = db.Address.Select(x => x.AddressDetail).FirstOrDefault();
            ViewBag.mail = db.Address.Select(x => x.Mail).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            db.Contact.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index","Default");
        }
        public ActionResult MessageList()
        {
            var values = db.Contact.ToList();
            return View(values);
        }
    }
}