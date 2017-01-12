using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWTest.Storage.Models
{
    public class BookModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public Guid? IdAuthor { get; set; }
        public Guid? IdCategory { get; set; }
    }
}
