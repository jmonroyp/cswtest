using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWTest.Storage
{
    public interface IStorageService<T> where T : class
    {
        void Upsert(T model);
        void Delete(Guid id);
        List<T> Get(SearchCriterias.SearchCriteria srcCriteria);
    }
}
