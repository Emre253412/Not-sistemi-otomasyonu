using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrencıNot.Controllers
{
    public class HesapMakinesiController : Controller
    {
        // GET: HesapMakinesi
        public ActionResult Index(int sayi2=0,int sayi1=0)
        {
            int sonuç = sayi1 + sayi2;
            ViewBag.snc = sonuç;
            return View();
        }
    }
}