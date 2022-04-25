using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetMVC1.Models.Entity;

namespace AspNetMVC1.Controllers
{
    public class MarkaController : Controller
    {
        // GET: Marka
        DbMarketEntities db = new DbMarketEntities();

        public ActionResult Index()
        {
            var degerler = db.TBLMARKA.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult NewMarka()
        {
            List<SelectListItem> degerler = (from i in db.TBLTOPTANCI.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.TOPTANCIAD,
                                                 Value = i.TOPTANCIID.ToString()
                                             }).ToList();
            ViewBag.degerler = degerler;              

            return View();
        }

        [HttpPost]
        public ActionResult NewMarka(TBLMARKA p1)
        {
            //var tptn = db.TBLTOPTANCI.Where(m => m.TOPTANCIID == p1.TOPTANCI).FirstOrDefault();
            if (!ModelState.IsValid)//
            {
                List<SelectListItem> degerler = (from i in db.TBLTOPTANCI.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.TOPTANCIAD,
                                                     Value = i.TOPTANCIID.ToString()
                                                 }).ToList();
                ViewBag.degerler = degerler;
                return View("NewMarka");
            }
            var tptn = db.TBLTOPTANCI.Find(p1.TOPTANCI);
            p1.TBLTOPTANCI = tptn;
            
            db.TBLMARKA.Add(p1);
            db.SaveChanges();
            ViewBag.Messag = "Marka EKLENDİ";
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var deletedvalue = db.TBLMARKA.Find(id);
            db.TBLMARKA.Remove(deletedvalue);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
         public ActionResult Update(int id)
        {
            List<SelectListItem> degerler = (from i in db.TBLTOPTANCI.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.TOPTANCIAD,
                                                 Value = i.TOPTANCIID.ToString()
                                             }).ToList();
            ViewBag.degerler = degerler;
            var value = db.TBLMARKA.Find(id);
            return View(value);
        }
        public ActionResult UpdateExecute(TBLMARKA p1)
        {
            var mrk = db.TBLMARKA.Find(p1.MARKALARID);
            mrk.MARKAAD = p1.MARKAAD;

            var tptn = db.TBLTOPTANCI.Find(p1.TOPTANCI);
            mrk.TBLTOPTANCI = tptn;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}