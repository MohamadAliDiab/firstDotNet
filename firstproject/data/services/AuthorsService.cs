using firstproject.data.models;
using firstproject.data.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstproject.data.services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }
        public void AddAuthor(AuthorVM book)
        {
            var _author = new author()
            {
                FullName = book.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorwithBooksVM GetAuthorwithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorwithBooksVM()
            {
                FullName = n.FullName,
                BookTitles = n.book_authors.Select(n => n.book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }
    }
}
