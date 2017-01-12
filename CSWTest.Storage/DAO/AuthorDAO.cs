using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSWTest.Storage.Database;

namespace CSWTest.Storage.DAO
{
    class AuthorDAO
    {
        public void Upsert(Models.AuthorModel item)
        {
            using (Entities db = new Entities())
            {
                var old = db.Authors1.Find(item.Id);
                if (old != null)
                    old.Name = item.Name;
                else
                    db.Authors1.Add(new Author()
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
                var item = db.Authors1.Find(id);
                if (item != null)
                    if (item.books != null && item.books.Count() > 0)
                    {
                        throw new Exception("Author has related books. It is not possible to delete it.");
                    }
                    else
                    {
                        db.Authors1.Remove(item);
                        db.SaveChanges();
                    }
            }
        }

        public List<Models.AuthorModel> Get(SearchCriterias.AuthorSearchCriteria srcCriteria)
        {
            using (Entities db = new Entities())
            {
                return db.Authors1.OrderBy(d => d.Name).Skip(srcCriteria.Index).Take(srcCriteria.PageSize)
                    .Select(a => new Models.AuthorModel()
                    {
                        Id = a.Id,
                        Name = a.Name
                    }).ToList();
            }
        }
    }
}
