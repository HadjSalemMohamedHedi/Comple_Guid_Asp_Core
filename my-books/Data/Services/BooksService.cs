using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead.Value,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                Author = book.Author,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }


        public List<Book> GetAllBook()
        {
            var allBooks = _context.Books.ToList();
            return allBooks;
        }

        public Book GetBookById(int idBook)
        {
            return _context.Books.FirstOrDefault(Book => Book.Id == idBook);

        }


        public Book UpdateBookById(int BookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == BookId);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead.Value;
                _book.Rate = book.Rate;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;
                _book.Author = book.Author;
                _context.SaveChanges();
            };
            return _book;
        }


        public bool DeletingBookByid(int id)
        {
            var _book = _context.Books.FirstOrDefault(_book => _book.Id == id);
            if (_book != null)
            {

                _context.Books.Remove(_book);
                _context.SaveChanges();
                return true;
            }
            return false;
        }


    }
}
