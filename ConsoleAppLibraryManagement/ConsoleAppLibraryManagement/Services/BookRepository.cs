using CollegeLibraryManagement.Models;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace CollegeLibraryManagement.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly Dictionary<string, Book> _books = new Dictionary<string, Book>();

        // Add book
        public void AddBook(Book book)
        {
            if (!_books.ContainsKey(book.BookId))
            {
                _books[book.BookId] = book;
            }
        }

        // Edit book
        public void EditBook(string bookId, Book updatedBook)
        {
            if (_books.ContainsKey(bookId))
            {
                _books[bookId].Title = updatedBook.Title;
                _books[bookId].Author = updatedBook.Author;
                _books[bookId].Publisher = updatedBook.Publisher;
                _books[bookId].Year = updatedBook.Year;
            }
        }

        // Delete book
        public void DeleteBook(string bookId)
        {
            if (_books.ContainsKey(bookId))
            {
                _books.Remove(bookId);
            }
        }

        // Search book
        public Book SearchBook(string keyword)
        {
            keyword = keyword.ToLower();
            foreach (var book in _books.Values)
            {
                if (book.Title.ToLower().Contains(keyword) ||
                    book.Author.ToLower().Contains(keyword) ||
                    book.Isbn.ToLower().Contains(keyword))
                {
                    return book;
                }
            }
            return null;
        }

        // Get all books
        public List<Book> GetAllBooks()
        {
            return new List<Book>(_books.Values);
        }
    }
}
