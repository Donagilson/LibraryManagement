using CollegeLibraryManagement.Services;
using System;

namespace CollegeLibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IBookRepository bookRepository = new BookRepository();
            LibraryService libraryService = new LibraryService(bookRepository);


            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Library Management ---");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Edit Book");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4. Search Book");
                Console.WriteLine("5. Display All Books");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        libraryService.AddBook();
                        break;
                    case "2":
                        libraryService.EditBook();
                        break;
                    case "3":
                        libraryService.DeleteBook();
                        break;
                    case "4":
                        libraryService.SearchBook();
                        break;
                    case "5":
                        libraryService.DisplayAllBooks();
                        break;
                    case "6":
                        exit = true;
                        Console.WriteLine("Exiting... Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again!");
                        break;
                }

            }
        }
    }
}


































