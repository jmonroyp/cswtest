using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSWTest.Storage.Database;
using CSWTest.Storage.Models;

namespace CSWTest.Storage.DAO
{
    class CategoryDAO
    {
        public void Upsert(CategoryModel item)
        {
            using (Entities db = new Entities())
            {
                var old = db.Categories1.Find(item.Id);
                if (old != null)
                    old.Name = item.Name;
                else
                    db.Categories1.Add(new Category()
                    {
                        Id = item.Id,
                        Name = item.Name
                    });
                db.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (Entities db = new Entities())
            {
                var item = db.Categories1.Find(id);
                if (item != null)
                    if (item.books != null && item.books.Count() > 0)
                        throw new Exception("Category has related books. It is not possible to delete it.");
                    else
                    {
                        db.Categories1.Remove(item);
                        db.SaveChanges();
                    }
            }
        }

        public List<CategoryModel> Get(SearchCriterias.CategorySearchCriteria srcCriteria)
        {
            using (Entities db = new Entities())
            {
                return db.Categories1.OrderBy(d => d.Name).Skip(srcCriteria.Index).Take(srcCriteria.PageSize)
                    .Select(o => new Models.CategoryModel()
                    {
                        Id = o.Id,
                        Name = o.Name
                    }).ToList();
            }
        }
    }
}
