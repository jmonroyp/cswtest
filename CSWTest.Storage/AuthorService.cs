using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSWTest.Storage.Database;
using CSWTest.Storage.SearchCriterias;
using CSWTest.Storage.Models;

namespace CSWTest.Storage
{
    public class AuthorService : IStorageService<AuthorModel>
    {
        public void Delete(Guid id)
        {
            new DAO.AuthorDAO().Delete(id);
        }

        public List<Models.AuthorModel> Get(SearchCriteria srcCriteria)
        {
            return new DAO.AuthorDAO().Get(srcCriteria as AuthorSearchCriteria);
        }

        public void Upsert(AuthorModel model)
        {
            new DAO.AuthorDAO().Upsert(model);
        }
    }
}
