using KutuphaneProgrami.Data.Model;
using KutuphaneProgrami.Data.UnitOfWork;
using System.Web.Mvc;

namespace MVC_projesi.Controllers
{
    public class YazarController : Controller
    {
        UnitOfWork unitOfWork;
        public YazarController()
        {
            unitOfWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            var yazarlar = unitOfWork.GetRepository<Yazar>().GetAll();

            return View(yazarlar);
        }

        [HttpPost]
        public JsonResult EkleJson(string yzrAd)
        {
            Yazar yazar = new Yazar();
            yazar.YazarAdi = yzrAd;
            var eklenenyazar = unitOfWork.GetRepository<Yazar>().Add(yazar);
            unitOfWork.SaveChanges();
            return Json(
                new
                {
                    Result = new
                    {

                        eklenenyazar.Id,
                        eklenenyazar.YazarAdi


                    },
                    JsonRequestBehavior.AllowGet
                }
            );
        }

        [HttpPost]
        public JsonResult SilJson(int yazarId)
        {
            unitOfWork.GetRepository<Yazar>().Delete(yazarId);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0) return Json("1");
            return Json("0");
        }

        [HttpPost]
        public JsonResult GuncelleJson(int yzrId, string yzrAd)
        {
            var yazar = unitOfWork.GetRepository<Yazar>().GetById(yzrId);
            yazar.YazarAdi = yzrAd;
            var durum = unitOfWork.SaveChanges();
            if (durum > 0) return Json("1");
            return Json("0");
        }


    }
}