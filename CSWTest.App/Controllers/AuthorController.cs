using CSWTest.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSWTest.App.Controllers
{
    public class AuthorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get(int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                var items = new AuthorService().Get(new Storage.SearchCriterias.AuthorSearchCriteria()
                {
                    Index = jtStartIndex,
                    PageSize = jtPageSize
                });
                return Json(new { Result = "OK", Records = items }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult GetOptions()
        {
            try
            {
                var items = new AuthorService().Get(new Storage.SearchCriterias.AuthorSearchCriteria()
                {
                    Index = 0,
                    PageSize = Int32.MaxValue
                })
                .Select(c => new { DisplayText = c.Name, Value = c.Id })
                .OrderBy(s => s.DisplayText);

                return Json(new { Result = "OK", Options = items }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult Post(Storage.Models.AuthorModel item)
        {
            try
            {
                item.Id = Guid.NewGuid();
                new AuthorService().Upsert(item);
                return Json(new { Result = "OK", Record = item });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult Put(Storage.Models.AuthorModel item)
        {
            try
            {
                new AuthorService().Upsert(item);
                return Json(new { Result = "OK", Record = item });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult Delete(Guid Id)
        {
            try
            {
                new AuthorService().Delete(Id); ;
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }

        }
    }
}
