using System;

namespace CollegeLibraryManagement.Models
{
    public class Book
    {
        private static Random random = new Random();
        private static int counter = 1; // for sequential BookId


        //feilds or propertise
        public string BookId { get; private set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; private set; }  // auto-generated
        public string Publisher { get; set; }
        public int Year { get; set; }

        // Constructor for adding book (ISBN auto-generated, BookId sequential)
        public Book(string title, string author, string publisher, int year)
        {
            BookId = $"{counter++:D4}"; // e.g., 0001, 0002, 0003...
            Title = title;
            Author = author;
            Publisher = publisher;
            Year = year;
            Isbn = GenerateIsbn();
        }

        //  method to auto-generate ISBN
        private string GenerateIsbn()
        {
            return $"ISBN-{random.Next(1, 5)}";
        }
    }
}
