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
    public class CategoryService : IStorageService<CategoryModel>
    {
        public void Delete(Guid id)
        {
            new DAO.CategoryDAO().Delete(id);
        }

        public List<Models.CategoryModel> Get(SearchCriteria srcCriteria)
        {
            return new DAO.CategoryDAO().Get(srcCriteria as CategorySearchCriteria);
        }

        public void Upsert(CategoryModel model)
        {
            new DAO.CategoryDAO().Upsert(model);
        }
    }
}
