using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWTest.Storage.SearchCriterias
{
    public class SearchCriteria
    {
        public int PageSize { get; set; }
        public int Index { get; set; }
    }

    public class AuthorSearchCriteria : SearchCriteria
    {

    }

    public class CategorySearchCriteria : SearchCriteria
    {

    }

    public class BookSearchCriteria : SearchCriteria
    {
        public Guid? IdAuthor { get; set; }
        public Guid? IdCategory { get; set; }
    }
}
