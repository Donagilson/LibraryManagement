using CollegeLibraryManagement.Models;
using System.Collections.Generic;

namespace CollegeLibraryManagement.Services
{
    public interface IBookRepository
    {

        //methods

        void AddBook(Book book);
        void EditBook(string bookId, Book updatedBook);
        void DeleteBook(string bookId);
        Book SearchBook(string keyword);
        List<Book> GetAllBooks();
    }
}