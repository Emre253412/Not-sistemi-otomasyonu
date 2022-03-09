using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrencıNot.Models.EntityFramework;
using OgrencıNot.Models;
namespace OgrencıNot.Controllers
{
    public class NOTLARController : Controller
    {
        DbmvcOkulEntities db = new DbmvcOkulEntities();
        public ActionResult Index()
        {
            var notlar = db.NOTLAR.ToList();
            return View(notlar);
        }
        [HttpGet]
        public ActionResult YeniSınav()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult YeniSınav(NOTLAR not)
        {
            db.NOTLAR.Add(not);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult NotlarGetır(int id)
        {
            var notlar = db.NOTLAR.Find(id);
            return View("NotlarGetır",notlar);
        }
        [HttpPost]
        public ActionResult NotlarGetır(Class1 model , NOTLAR p, int SINAV1 = 0, int SINAV2 = 0, int SINAV3 = 0 , int PROJE = 0)
        {
            if (model.islem == "HESAPLA")
            {
                int ORTALAMA = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ort = ORTALAMA;
            }

            if (model.islem == "NOTGUNCELLE")
            {
                var snv = db.NOTLAR.Find(p.NOTID);
                snv.SINAV1 = p.SINAV1;
                snv.SINAV2 = p.SINAV2;
                snv.SINAV3 = p.SINAV3;
                snv.PROJE = p.PROJE;
                snv.ORTALAMA = p.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index", "NOTLAR");




            }
            return View();
        }
    }
}