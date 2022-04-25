using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetMVC1.Models.Entity;

namespace AspNetMVC1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        DbMarketEntities db = new DbMarketEntities();
        

        public ActionResult Index()
        {
            var degerler = db.TBLPRODUCT.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> degerler = (from i in db.TBLMARKA.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.MARKAAD,
                                                 Value = i.MARKALARID.ToString()
                                             }).ToList();
            ViewBag.degerler = degerler;


            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(TBLPRODUCT p1)
        {
            var mrk = db.TBLMARKA.Find(p1.TBLMARKA.MARKALARID);
            p1.TBLMARKA = mrk;
            ViewBag.Message = "Product Eklendi";
            db.TBLPRODUCT.Add(p1);
            db.SaveChanges();
            return  RedirectToAction("Index");

        }

        public ActionResult Sil(int id)
        {
            var deletedvalue = db.TBLPRODUCT.Find(id);
            db.TBLPRODUCT.Remove(deletedvalue);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}