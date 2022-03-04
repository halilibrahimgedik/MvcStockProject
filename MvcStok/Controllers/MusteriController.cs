using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.EntityFramework;               

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri

        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERILER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MusteriEkle(TBLMUSTERILER p2)
        {
            db.TBLMUSTERILER.Add(p2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var degerler = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(degerler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var msgetir = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir",msgetir);
        }
        public ActionResult Guncelle(TBLMUSTERILER p5)
        {
            var musteri = db.TBLMUSTERILER.Find(p5.MUSTERIID);
            musteri.MUSTERIAD = p5.MUSTERIAD;
            musteri.MUSTERISOYAD = p5.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}