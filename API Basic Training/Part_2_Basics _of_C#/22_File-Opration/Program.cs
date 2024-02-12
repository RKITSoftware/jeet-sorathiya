using System;
using System.IO;

namespace _22_File_Opration
{
    /// <summary>
    /// file operations in C#.
    /// </summary>
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

        /// <summary>
        /// Writes content to a file.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        /// <param name="content">The content to write to the file.</param>
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

        /// <summary>
        /// Reads content from a file.
        /// </summary>
        /// <param name="filePath">The path of the file to read.</param>
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

        /// <summary>
        /// Appends additional content to a file.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        /// <param name="additionalContent">The content to append to the file.</param>
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

        /// <summary>
        /// Deletes a file.
        /// </summary>
        /// <param name="filePath">The path of the file to delete.</param>
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
