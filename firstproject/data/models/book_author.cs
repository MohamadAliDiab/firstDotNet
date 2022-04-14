using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstproject.data.models
{
    public class book_author
    {
        public int Id { get; set; }
        public int bookId { get; set; }
        public book book { get; set; }
        public int authorId { get; set; }
        public author Author { get; set; }
    }
}
