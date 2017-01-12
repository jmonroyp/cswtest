using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSWTest.Storage.SearchCriterias;
using CSWTest.Storage.Models;

namespace CSWTest.Storage
{
    public class BookService : IStorageService<BookModel>
    {
        public void Delete(Guid id)
        {
            new DAO.BookDAO().Delete(id);
        }

        public List<Models.BookModel> Get(SearchCriteria srcCriteria)
        {
            return new DAO.BookDAO().Get(srcCriteria as BookSearchCriteria);
        }

        public void Upsert(BookModel model)
        {
            new DAO.BookDAO().Upsert(model);
        }
    }
}
