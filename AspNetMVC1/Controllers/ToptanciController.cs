using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetMVC1.Models.Entity;

namespace AspNetMVC1.Controllers
{
    public class ToptanciController : Controller
    {
        // GET: Toptanci
        DbMarketEntities db = new DbMarketEntities();

        public ActionResult Index()
        {
            var degerler = db.TBLTOPTANCI.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult NewToptanci()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewToptanci(TBLTOPTANCI p1)
        {
            if(!ModelState.IsValid)
            {
                return View("NewToptanci");
            }
            db.TBLTOPTANCI.Add(p1);
            db.SaveChanges();
            ViewBag.Message = "TOPTANCI EKLENDİ";
            return View();
        }

        public ActionResult Sil(int id)
        {
            var deletedvalue = db.TBLTOPTANCI.Where(x => x.TOPTANCIID == id).FirstOrDefault();
            db.TBLTOPTANCI.Remove(deletedvalue);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var value = db.TBLTOPTANCI.Find(id);
            return View(value);
        }

        public ActionResult UpdateExecute(TBLTOPTANCI p1)
        {
            var tptn = db.TBLTOPTANCI.Find(p1.TOPTANCIID);
            tptn.TOPTANCIAD = p1.TOPTANCIAD;
            tptn.TOPTANCISOYAD = p1.TOPTANCISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}