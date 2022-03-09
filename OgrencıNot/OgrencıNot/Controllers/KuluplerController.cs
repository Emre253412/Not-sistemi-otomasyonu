using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrencıNot.Models.EntityFramework;
namespace OgrencıNot.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbmvcOkulEntities db = new DbmvcOkulEntities();
        public ActionResult Index()
        {
            var kulupler = db.KULUPLER.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YenıKulupler()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YenıKulupler(KULUPLER k)
        {
            db.KULUPLER.Add(k);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kulup = db.KULUPLER.Find(id);
            db.KULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetır(int id)
        {
            var kulup = db.KULUPLER.Find(id);
            return View("KulupGetır",kulup);
        }
        public ActionResult Guncelle(KULUPLER p)
        {
            var klp = db.KULUPLER.Find(p.KULUPID);
            klp.KULUPADI =p.KULUPADI;
            db.SaveChanges();
            return RedirectToAction("Index","Kulupler");
        }
    }
}