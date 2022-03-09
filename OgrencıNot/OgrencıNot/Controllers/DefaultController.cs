using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrencıNot.Models.EntityFramework;
namespace OgrencıNot.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbmvcOkulEntities db = new DbmvcOkulEntities();
        public ActionResult Index()
        {
            var dersler = db.DERSLER.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YenıDers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YenıDers(DERSLER P)
        {
            db.DERSLER.Add(P);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var ders = db.DERSLER.Find(id);
            db.DERSLER.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetır(int id)
        {
            var ders = db.DERSLER.Find(id);
            return View("DersGetır",ders);
        }
        public ActionResult Guncelle(DERSLER p)
        {
            var drs = db.DERSLER.Find(p.DERSID);
            drs.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}