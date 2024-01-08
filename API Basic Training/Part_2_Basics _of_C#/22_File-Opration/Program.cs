using System;
using System.IO;

namespace _22_File_Opration
{
    internal class Program
    {
        static void Main()
        {
            // File path
            string filePath = "jeet.txt";

            // Create and write to a file
            WriteToFile(filePath, "Hello, jeet sorathiya");

            // Read from the file
            ReadFromFile(filePath);

            // Append additional content to the file
            AppendToFile(filePath, "\nGood Morning");

            // Read from the file again
            ReadFromFile(filePath);

            // Delete the file
            DeleteFile(filePath);
        }

        static void WriteToFile(string filePath, string content)
        {
            try
            {
                File.WriteAllText(filePath, content);
                Console.WriteLine("File created and written successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to the file: " + ex.Message);
            }
        }

        static void ReadFromFile(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine("File content:\n" + content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading from the file: " + ex.Message);
            }
        }

        static void AppendToFile(string filePath, string additionalContent)
        {
            try
            {
                File.AppendAllText(filePath, additionalContent);
                Console.WriteLine("Additional content appended to the file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error appending to the file: " + ex.Message);
            }
        }

        static void DeleteFile(string filePath)
        {
            try
            {
                // Delete the file
                File.Delete(filePath);
                Console.WriteLine("File deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting the file: " + ex.Message);
            }
        }
    }
}
