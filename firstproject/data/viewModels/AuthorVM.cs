using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstproject.data.viewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }
    public class AuthorwithBooksVM
    {
        public string FullName { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
