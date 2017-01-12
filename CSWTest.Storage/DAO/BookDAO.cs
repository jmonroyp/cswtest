using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSWTest.Storage.Database;
using CSWTest.Storage.Models;

namespace CSWTest.Storage.DAO
{
    class BookDAO
    {
        public void Upsert(BookModel item)
        {
            using (Entities db = new Entities())
            {
                var old = db.Books1.Find(item.Id);
                if (old != null)
                {
                    old.Name = item.Name;
                    old.IdAuthor = item.IdAuthor;
                    old.IdCategory = item.IdCategory;
                    old.Picture = item.Picture;
                    old.Price = item.Price;
                    old.Summary = item.Summary;
                }
                else
                    db.Books1.Add(new Book()
                    {
                        Id = item.Id,
                        IdAuthor = item.IdAuthor,
                        IdCategory = item.IdCategory,
                        Name = item.Name,
                        Picture = item.Picture,
                        Price = item.Price,
                        Summary = item.Summary
                    });
                db.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (Entities db = new Entities())
            {
                var item = db.Books1.Find(id);
                if (item != null)
                {
                    db.Books1.Remove(item);
                    db.SaveChanges();
                }
            }
        }

        public List<BookModel> Get(SearchCriterias.BookSearchCriteria srcCriteria)
        {
            using (Entities db = new Entities())
            {
                return db.Books1
                    .Where(x =>
                (srcCriteria.IdAuthor != null ? x.IdAuthor == srcCriteria.IdAuthor : true) &&
                (srcCriteria.IdCategory != null ? x.IdCategory == srcCriteria.IdCategory : true)
                    )
                    .OrderBy(d => d.Name)
                    .Skip(srcCriteria.Index).Take(srcCriteria.PageSize)
                    .Select(c => new BookModel()
                    {
                        Id = c.Id,
                        IdAuthor = c.IdAuthor,
                        IdCategory = c.IdCategory,
                        Name = c.Name,
                        Picture = c.Picture,
                        Price = c.Price,
                        Summary = c.Summary
                    }).ToList();
            }
        }
    }
}
