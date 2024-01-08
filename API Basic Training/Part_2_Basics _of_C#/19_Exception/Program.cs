using System;

namespace _19_Exception
{
    internal class Program
    {
        static void Main()
        {
            // Code that may cause an exception
            try
            {
                Console.Write("Enter a number: ");
                string userInput = Console.ReadLine();

                int parsedNumber = ParseNumber(userInput);
                int result = 10 / parsedNumber;

                // This line will not be executed if an exception occurs above
                Console.WriteLine($"Result of division: {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Please enter a valid number.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Cannot divide by zero.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {

                Console.WriteLine("Finally block executed ");
            }

            // Rest of the program continues to execute after exception handling
            Console.WriteLine("Program continues to execute.");
        }

        /// <summary>
        /// convert string to an integer and throws a custom exception if parsing fails.
        /// </summary>
        /// <param name="input">The input string to parse.</param>
        /// <returns>The parsed integer.</returns>
        static int ParseNumber(string input)
        {
            try
            {
                return int.Parse(input);
            }
            catch (FormatException)
            {
                // Throwing a custom exception if parsing fails
                throw new Exception("Failed to parse the input to an integer.");
            }
        }
    }

}
