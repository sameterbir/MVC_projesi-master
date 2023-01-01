using KutuphaneProgrami.Data.Model;
using KutuphaneProgrami.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC_projesi.Controllers
{
    public class KitapController : Controller
    {
        UnitOfWork unitOfWork;

        public KitapController()
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var kitaplar = unitOfWork.GetRepository<Kitap>().GetAll();

            return View(kitaplar);
        }

        public ActionResult Ekle()
        {
            ViewBag.Kategoriler = unitOfWork.GetRepository<Kategori>().GetAll();
            ViewBag.Yazarlar = unitOfWork.GetRepository<Yazar>().GetAll();
            return View();

        }


        [HttpPost]
        public JsonResult EkleJson(string[] kategoriler, string yazar, string kitapAd, string kitapAdet, string siraNo)
        {

            if (kategoriler != null && !string.IsNullOrEmpty(yazar) && !string.IsNullOrEmpty(kitapAd) && !string.IsNullOrEmpty(kitapAdet) && !string.IsNullOrEmpty(siraNo))
            {
                List<Kategori> k = new List<Kategori>();
                foreach (var kategoriId in kategoriler)
                {
                    var kategoriID = Convert.ToInt32(kategoriId);
                    var kategori = unitOfWork.GetRepository<Kategori>().GetById(kategoriID);
                    k.Add(kategori);
                }

                Kitap kitap = new Kitap();
                kitap.Ad = kitapAd;
                kitap.Adet = Convert.ToInt32(kitapAdet);
                kitap.YazarId = Convert.ToInt32(yazar);
                kitap.SiraNo = siraNo;
                kitap.Kategoriler = k;             
                kitap.EklenmeTarihi = DateTime.Now;
                unitOfWork.GetRepository<Kitap>().Add(kitap);
                var durum = unitOfWork.SaveChanges();
                if (durum > 0)               
                    return Json("1");               
                else              
                    return Json("0");
                
            }
            else
            {
                return Json("bosOlamaz");
            }

    }
        [HttpPost]
        public JsonResult SilJson(int kitapId)
        {
            unitOfWork.GetRepository<Kitap>().Delete(kitapId);
            int durum = unitOfWork.SaveChanges();
            if (durum > 0)
                return Json("1");
            else
                return Json("0");



        }
        
        public ActionResult Guncelle(int kitapId)
        {
            ViewBag.Kategoriler = unitOfWork.GetRepository<Kategori>().GetAll();
            ViewBag.Yazarlar = unitOfWork.GetRepository<Yazar>().GetAll();
            var kitap = unitOfWork.GetRepository<Kitap>().GetById(kitapId);
            return View(kitap);
        }

        [HttpPost]
        public JsonResult GuncelleJson(int kitapId , string[] kategoriler, string yazar, string kitapAd, string kitapAdet, string siraNo )
        {

            if (kategoriler != null && !string.IsNullOrEmpty(yazar) && !string.IsNullOrEmpty(kitapAd) && !string.IsNullOrEmpty(kitapAdet) && !string.IsNullOrEmpty(siraNo))
            {
                List<Kategori> k = new List<Kategori>();
                foreach (var kategoriId in kategoriler)
                {
                    var kategoriID = Convert.ToInt32(kategoriId);
                    var kategori = unitOfWork.GetRepository<Kategori>().GetById(kategoriID);
                    k.Add(kategori);
                }

                var kitap = unitOfWork.GetRepository<Kitap>().GetById(kitapId);              
                kitap.Ad = kitapAd;
                kitap.Adet = Convert.ToInt32(kitapAdet);
                kitap.YazarId = Convert.ToInt32(yazar);
                kitap.SiraNo = siraNo;
                kitap.Kategoriler.Clear();
                kitap.Kategoriler = k;              
                unitOfWork.GetRepository<Kitap>().Update(kitap);
                var durum = unitOfWork.SaveChanges();
                if (durum > 0)
                    return Json("1");
                else
                    return Json("0");

            }
            else
            {
                return Json("bosOlamaz");
            }

        }

    }
}