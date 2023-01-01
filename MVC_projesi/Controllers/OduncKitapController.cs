using KutuphaneProgrami.Data.Model;
using KutuphaneProgrami.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_projesi.Controllers
{
    public class OduncKitapController : Controller
    {

        UnitOfWork unitOfWork;

        public OduncKitapController()
        {
            unitOfWork = new UnitOfWork();
        
        }

        public ActionResult VerilenKitap() 
        {
            var oduncKitap = unitOfWork.GetRepository<OduncKitap>().GetAll();
            return View(oduncKitap);

        }

        public ActionResult TeslimEdilenKitap()
        {

            return View();

        }

        public ActionResult KitapVer()
        {
            ViewBag.Kitaplar = unitOfWork.GetRepository<Kitap>().GetAll(x => x.Adet > 0);
            ViewBag.Uyeler = unitOfWork.GetRepository<Uye>().GetAll();
            return View();

        }

        [HttpPost]
        public JsonResult KitapVerJson(int uyeId , int kitapId , DateTime getirecegiTarih)
        {
            OduncKitap oduncKitap = new OduncKitap();
            oduncKitap.AlisTarihi = DateTime.Now;
            oduncKitap.GetirecegiTarih = getirecegiTarih;
            oduncKitap.KitapId = kitapId;
            oduncKitap.UyeId = uyeId;
            unitOfWork.GetRepository<OduncKitap>().Add(oduncKitap);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0)
                return Json("1");
            else
                return Json("0");

        }

        public ActionResult VerilenKitabiGuncelle(int oduncKitapId)
        {
            ViewBag.Kitaplar = unitOfWork.GetRepository<Kitap>().GetAll(x => x.Adet > 0);
            ViewBag.Uyeler = unitOfWork.GetRepository<Uye>().GetAll();
            var oduncKitap = unitOfWork.GetRepository<OduncKitap>().GetById(oduncKitapId);
            return View(oduncKitap);
        
        }


        [HttpPost]
        public JsonResult VerilenKitabiGuncelleJson(int oduncKitapId, int uyeId, int kitapId, DateTime getirecegiTarih)
        {
            var oduncKitap = unitOfWork.GetRepository<OduncKitap>().GetById(oduncKitapId);
            oduncKitap.GetirecegiTarih = getirecegiTarih;
            oduncKitap.KitapId = kitapId;
            oduncKitap.UyeId = uyeId;
            unitOfWork.GetRepository<OduncKitap>().Update(oduncKitap);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0)
                return Json("1");
            else
                return Json("0");

        }

    }

}