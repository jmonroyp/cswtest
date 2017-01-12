using CSWTest.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSWTest.App.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get(int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                var items = new CategoryService().Get(new Storage.SearchCriterias.CategorySearchCriteria()
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
                var items = new CategoryService().Get(new Storage.SearchCriterias.CategorySearchCriteria()
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

        public JsonResult Post(Storage.Models.CategoryModel item)
        {
            try
            {
                item.Id = Guid.NewGuid();
                new CategoryService().Upsert(item);
                return Json(new { Result = "OK", Record = item });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }



        public JsonResult Put(Storage.Models.CategoryModel item)
        {
            try
            {
                new CategoryService().Upsert(item);
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
                new CategoryService().Delete(Id); ;
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }

        }
    }
}
