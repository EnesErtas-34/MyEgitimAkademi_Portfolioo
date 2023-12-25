using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyEgitimAkademi_Portfolioo.Models;

namespace MyEgitimAkademi_Portfolioo.Controllers
{
    public class LoginController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var values = db.Admin.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["username"] = values.UserName.ToString();//sisteme authentication olan kullanıcının bilgilerini diğer sayfaya taşır
                return RedirectToAction("Index", "Service");
            }
            return View();
        }
    }
}