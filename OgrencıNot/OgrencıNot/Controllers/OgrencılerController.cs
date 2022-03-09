using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrencıNot.Models.EntityFramework;
namespace OgrencıNot.Controllers
{
    public class OgrencılerController : Controller
    {
        // GET: Ogrencıler
        DbmvcOkulEntities db = new DbmvcOkulEntities();
        public ActionResult Index()
        {
            var ogrencıler = db.OGRENCILER.ToList();
            return View(ogrencıler);
        }
        [HttpGet]
        public ActionResult YenıOgrencıler()
        {
            List<SelectListItem> degerler = (from i in db.KULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPADI,
                                                 Value = i.KULUPID.ToString()
                                             }
                                            ).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YenıOgrencıler(OGRENCILER O)
        {
            var klp = db.KULUPLER.Where(m => m.KULUPID == O.KULUPLER.KULUPID).FirstOrDefault();
            O.KULUPLER=klp;
            db.OGRENCILER.Add(O);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ogrencı = db.OGRENCILER.Find(id);
            db.OGRENCILER.Remove(ogrencı);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrencıGetır(int id)
        {
            var ogrencı = db.OGRENCILER.Find(id);
            return View("OgrencıGetır", ogrencı);
        }
        public ActionResult Guncelle(OGRENCILER p)
        {
            var ogr= db.OGRENCILER.Find(p.OGRENCIID);
           ogr.OGRENCIAD = p.OGRENCIAD;
            ogr.OGRENCISOYAD = p.OGRENCISOYAD;
            ogr.OGRENCICINSIYET = p.OGRENCICINSIYET;
            ogr.OGRENCIKULUP = p.OGRENCIKULUP;
            ogr.OGRENCIFOTOGRAF = p.OGRENCIFOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrencıler");
        }
    }
}