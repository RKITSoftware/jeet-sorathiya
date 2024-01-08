using System;

namespace _21_DateTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating a DateTime object
            DateTime currentDateTime = DateTime.Now;
            Console.WriteLine("Current Date and Time: " + currentDateTime);

            int year = currentDateTime.Year;
            int month = currentDateTime.Month;
            int day = currentDateTime.Day;
            int hour = currentDateTime.Hour;
            int minute = currentDateTime.Minute;
            int second = currentDateTime.Second;

            Console.WriteLine($"Year: {year}, Month: {month}, Day: {day}, Hour: {hour}, Minute: {minute}, Second: {second}");

            // Creating a DateTime object for a specific date and time
            DateTime specificDateTime = new DateTime(2022, 5, 15, 14, 30, 0);
            Console.WriteLine("Specific Date and Time: " + specificDateTime);

            // Adding and subtracting time
            DateTime futureDateTime = currentDateTime.AddHours(24);
            DateTime pastDateTime = currentDateTime.AddMonths(-1);
            Console.WriteLine("Future Date and Time: " + futureDateTime);
            Console.WriteLine("Past Date and Time: " + pastDateTime);

            // Calculating the difference between two DateTime objects
            TimeSpan timeDifference = futureDateTime - currentDateTime;
            Console.WriteLine("Time Difference: " + timeDifference);

            // Formatting DateTime
            string formattedDateTime = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine("Formatted Date and Time: " + formattedDateTime);

            // string to DateTime object
            string dateString = "2023-08-21";
            DateTime parsedDateTime = DateTime.Parse(dateString);
            Console.WriteLine("Parsed Date: " + parsedDateTime);

        }
    }
}
