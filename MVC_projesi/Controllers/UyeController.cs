using KutuphaneProgrami.Data.Model;
using KutuphaneProgrami.Data.UnitOfWork;
using System;
using System.Web.Mvc;

namespace MVC_projesi.Controllers
{
    public class UyeController : Controller
    {
        UnitOfWork unitOfWork;
        public UyeController()
        {
            unitOfWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            var uyeler = unitOfWork.GetRepository<Uye>().GetAll();
            return View(uyeler);
        }
        public ActionResult Ekle()
        {

            return View();
        }

        [HttpPost]
        public JsonResult EkleJson(string uyeAd, string uyeSoyad, string uyeTc, string uyeTel)
        {
            if (!string.IsNullOrEmpty(uyeAd) && !string.IsNullOrEmpty(uyeSoyad))
            {
                Uye uye = new Uye();
                uye.Ad = uyeAd;
                uye.Soyad = uyeSoyad;
                uye.Tc = uyeTc;
                uye.Telefon = uyeTel;
                uye.Ceza = 0;
                uye.KayitTarihi = DateTime.Now;
                unitOfWork.GetRepository<Uye>().Add(uye);
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
        public JsonResult SilJson(int uyeId)
        {
            unitOfWork.GetRepository<Uye>().Delete(uyeId);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0) return Json("1");
            return Json("0");
        }

        public ActionResult Guncelle(int uyeId)
        {
   
            var uye = unitOfWork.GetRepository<Uye>().GetById(uyeId);
            return View(uye);
        }

        [HttpPost]
        public JsonResult GuncelleJson(int uyeId , string uyeAd, string uyeSoyad, string uyeTc, string uyeTel)
        {
            if (!string.IsNullOrEmpty(uyeAd) && !string.IsNullOrEmpty(uyeSoyad))
            {
                var uye = unitOfWork.GetRepository<Uye>().GetById(uyeId);
                uye.Ad = uyeAd;
                uye.Soyad = uyeSoyad;
                uye.Tc = uyeTc;
                uye.Telefon = uyeTel;                      
                unitOfWork.GetRepository<Uye>().Update(uye);
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