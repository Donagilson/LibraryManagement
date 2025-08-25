using System;
using System.Linq;

namespace ConsoleAppLibraryManagement.Validation
{
    public static class InputValidator
    {
        // Validate general string (non-empty)
        public static string ValidateString(string input)
        {
            input = input.Trim();
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Input cannot be empty. Please enter a valid string: ");
                input = Console.ReadLine()?.Trim();
            }
            return input;
        }

        // Validate name fields (Author/Publisher) - only letters allowed
        public static string ValidateName(string input, string fieldName)
        {
            input = input.Trim();
            while (string.IsNullOrWhiteSpace(input) || input.Any(char.IsDigit))
            {
                Console.Write($"{fieldName} cannot be empty or contain numbers. Please enter a valid {fieldName}: ");
                input = Console.ReadLine()?.Trim();
            }
            return input;
        }

        // Validate publishing year
        public static int ValidateYear(string input)
        {
            int year;
            int currentYear = DateTime.Now.Year;

            while (!int.TryParse(input, out year) || year < 1000 || year > currentYear)
            {
                Console.Write($"Invalid year. Enter a valid year (1000-{currentYear}): ");
                input = Console.ReadLine();
            }
            return year;
        }
    }
}
