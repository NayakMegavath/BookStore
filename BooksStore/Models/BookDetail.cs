using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Models
{
    public class BookDetail
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
