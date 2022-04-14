using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstproject.data.models
{
    public class author
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        //Navigation properties
        public List<book_author> book_authors { get; set; }
    }
}
