using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.EntityFramework;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        
        MvcDbStokEntities db = new MvcDbStokEntities();

        public ActionResult Index(int sayfa=1)
        {
            //var degerler=db.TBLKATEGORILER.ToList();
            var degerler = db.TBLKATEGORILER.ToList().ToPagedList(sayfa,6);
            return View(degerler);
        }

        public ActionResult Index2(string p)
        {
            var degerler = from d in db.TBLKATEGORILER select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.KATEGORIAD.Contains(p));
            }
            return View(degerler.ToList());
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var kategori= db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgri = db.TBLKATEGORILER.Find(id);
            return View("KategoriGetir",ktgri);
        }

        public ActionResult GUncelle(TBLKATEGORILER p4)
        {
            var ktg = db.TBLKATEGORILER.Find(p4.KATEGORIID);
            ktg.KATEGORIAD = p4.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}