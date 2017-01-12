using CSWTest.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSWTest.App.Controllers
{
    public class BookController : Controller
    {
     //
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get(int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                var items = new BookService().Get(new Storage.SearchCriterias.BookSearchCriteria()
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

        public JsonResult Post(Storage.Models.BookModel item, HttpPostedFileBase DocBytes)
        {
            try
            {
                if (item.IdAuthor == null)
                    throw new Exception("Author is expected.");
                if (item.IdCategory == null)
                    throw new Exception("Category is expected.");
                item.Id = Guid.NewGuid();
                item.Picture = Utils.WebUtils.GetB64File(DocBytes);
                new BookService().Upsert(item);
                return Json(new { Result = "OK", Record = item });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult Put(Storage.Models.BookModel item, HttpPostedFileBase DocBytes)
        {
            try
            {
                if (item.IdAuthor == null)
                    throw new Exception("Author is expected.");
                if (item.IdCategory == null)
                    throw new Exception("Category is expected.");

                var picture = Utils.WebUtils.GetB64File(DocBytes);
                if (!string.IsNullOrEmpty(picture))
                    item.Picture = picture;
                new BookService().Upsert(item);
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
                new BookService().Delete(Id); ;
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }

        }

    }
}