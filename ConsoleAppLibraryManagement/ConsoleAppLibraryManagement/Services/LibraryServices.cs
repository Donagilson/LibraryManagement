using CollegeLibraryManagement.Models;
using ConsoleAppLibraryManagement.Validation;
using System;

namespace CollegeLibraryManagement.Services
{
    public class LibraryService
    {
        private readonly IBookRepository _bookRepository;
        


        public LibraryService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // Adding the books
        public void AddBook()
        {
            Console.Write("Enter Title: ");
            string title = InputValidator.ValidateString(Console.ReadLine());

            Console.Write("Enter Author: ");
            string author = InputValidator.ValidateName(Console.ReadLine(), "Author");

            Console.Write("Enter Publisher: ");
            string publisher = InputValidator.ValidateName(Console.ReadLine(), "Publisher");

            Console.Write("Enter Publishing Year: ");
            int year = InputValidator.ValidateYear(Console.ReadLine());

            var book = new Book(title, author, publisher,year);

            _bookRepository.AddBook(book);
            Console.WriteLine($"Book added successfully! (ID: {book.BookId}, ISBN: {book.Isbn})");
        }


        // Editing the books
        public void EditBook()
        {
            Console.Write("Enter Book ID to Edit: ");
            string bookId = InputValidator.ValidateString(Console.ReadLine());

            Console.Write("Enter New Title: ");
            string title = InputValidator.ValidateString(Console.ReadLine());

            Console.Write("Enter New Author: ");
            string author = InputValidator.ValidateString(Console.ReadLine());

            Console.Write("Enter New Publisher: ");
            string publisher = InputValidator.ValidateString(Console.ReadLine());



            Console.Write("Enter New ISBN: ");
            string isbn = InputValidator.ValidateString(Console.ReadLine());

            

            // Ask for new publishing year and validate
            Console.Write("Enter New Publishing Year: ");
            int year = InputValidator.ValidateYear(Console.ReadLine());

            var updatedBook = new Book(title, author, publisher, year);

            _bookRepository.EditBook(bookId, updatedBook);
            Console.WriteLine("Book updated successfully!");
        }


        // Deleting the books
        public void DeleteBook()
        {
            Console.Write("Enter Book ID to Delete: ");
            string bookId = InputValidator.ValidateString(Console.ReadLine());

            _bookRepository.DeleteBook(bookId);
            Console.WriteLine("Book deleted successfully!");
        }

        // Searching the books
        public void SearchBook()
        {
            Console.Write("Enter keyword (Title/Author/ISBN): ");
            string keyword = InputValidator.ValidateString(Console.ReadLine());

            var book = _bookRepository.SearchBook(keyword);
            if (book != null)
            {
                Console.WriteLine($"Found: {book.Title} by {book.Author}, ISBN: {book.Isbn}, Year: {book.Year}");
            }
            else
            {
                Console.WriteLine("No book found.");
            }
        }

        //Displaying the books


        public void DisplayAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.BookId}|  Title: {book.Title} |  Author: {book.Author} |  ISBN: {book.Isbn} |  Year: {book.Year}");
            }
        }


        
    }
}
