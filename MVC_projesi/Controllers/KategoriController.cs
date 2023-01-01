using KutuphaneProgrami.Data;
using KutuphaneProgrami.Data.Model;
using KutuphaneProgrami.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_projesi.Controllers
{
    public class KategoriController : Controller
    {

        UnitOfWork unitOfWork;

        public KategoriController()
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var kategoriler = unitOfWork.GetRepository<Kategori>().GetAll();

            return View(kategoriler);
        }



        [HttpPost]
        public JsonResult EkleJson(string ktgAd)
        {
            Kategori ktgri = new Kategori();
            ktgri.Ad = ktgAd;
            var eklenenKtg = unitOfWork.GetRepository<Kategori>().Add(ktgri);
            unitOfWork.SaveChanges();
            return Json(
                new
                {
                    Result = new
                    {

                        eklenenKtg.Id,
                        eklenenKtg.Ad
                        

                    }, JsonRequestBehavior.AllowGet
                }
            ); 
        }
        [HttpPost]
        public JsonResult GuncelleJson(int ktgId , string ktgAd)
        {
            var kategori = unitOfWork.GetRepository<Kategori>().GetById(ktgId);
            kategori.Ad = ktgAd;
            var durum = unitOfWork.SaveChanges();
            if (durum > 0) return Json("1");
            return Json("0");
        }


        [HttpPost]
        public JsonResult SilJson(int ktgId)
        {
            unitOfWork.GetRepository<Kategori>().Delete(ktgId);     
            var durum = unitOfWork.SaveChanges();
            if (durum > 0) return Json("1");
            return Json("0");
        }


    }
}