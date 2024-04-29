using File_System.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace File_System.BL
{
    /// <summary>
    /// Provides file operations related to Employee data.
    /// </summary>
    public static class BLFileOperation
    {
        // The directory and file paths
        static string currentDirectory = HttpContext.Current.Server.MapPath("~/Data");
        static string fileName = "employeeData.txt";
        static string filePath = Path.Combine(currentDirectory, fileName);

        /// <summary>
        /// Initializes the FileOperation class by creating the file if it doesn't exist.
        /// </summary>
        static BLFileOperation()
        {
            try
            {
                bool isFileExists = File.Exists(filePath);
                if (!isFileExists)
                {
                    File.Create(filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Adds employee data to the file.
        /// </summary>
        /// <param name="employeeData">The Employee object to be added.</param>
        public static void AddToFile(Employee employeeData)
        {
            string text = $"{employeeData.EmployeeID.ToString()}\t {employeeData.EmployeeName}\t" +
                $"{employeeData.EmailId}\t {employeeData.PhoneNumber}\t" +
                $"{employeeData.JobTitle}\t {employeeData.IsActive}\n";

            if (text.Length > 0)
            {
                File.AppendAllText(filePath, text);
            }
        }

        /// <summary>
        /// Reads employee data from the file.
        /// </summary>
        /// <returns>An array of Employee objects.</returns>
        public static Employee[] ReadFromFile()
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                Employee[] employees = new Employee[lines.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split('\t');

                    if (parts.Length == 6)
                    {
                        employees[i] = new Employee
                        {
                            EmployeeID = int.Parse(parts[0]),
                            EmployeeName = parts[1],
                            EmailId = parts[2],
                            PhoneNumber = parts[3],
                            JobTitle = parts[4],
                            IsActive = bool.Parse(parts[5])
                        };
                    }
                }

                return employees;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Employee[0];
            }

        }
        /// <summary>
        /// Retrieves information about an employee by their ID.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <returns>The Employee object if found, otherwise null.</returns>
        public static Employee EmployeeInfo(int employeeId)
        {
            var employees = ReadFromFile().ToList();

            int index = employees.FindIndex(e => e.EmployeeID == employeeId);

            if (index != -1)
            {
                return employees[index];
            }
            else
            {
                Console.WriteLine("Employee ID not found.");
                return null;
            }
        }

        /// <summary>
        /// Updates an employee's information by their ID.
        /// </summary>
        /// <param name="employeeId">The ID of the employee to update.</param>
        /// <param name="updatedEmployee">The updated Employee object.</param>
        public static void UpdateEmployeeById(int employeeId, Employee updatedEmployee)
        {

            var employees = ReadFromFile().ToList();


            var employeeToUpdate = employees.FirstOrDefault(e => e.EmployeeID == employeeId);

            if (employeeToUpdate != null)
            {

                employeeToUpdate.EmployeeName = updatedEmployee.EmployeeName;
                employeeToUpdate.EmailId = updatedEmployee.EmailId;
                employeeToUpdate.PhoneNumber = updatedEmployee.PhoneNumber;
                employeeToUpdate.JobTitle = updatedEmployee.JobTitle;
                employeeToUpdate.IsActive = updatedEmployee.IsActive;


                WriteToFile(employees.ToArray());
            }
            else
            {
                Console.WriteLine($"Employee with ID {employeeId} not found.");
            }
        }

        /// <summary>
        /// Deletes an employee by their ID.
        /// </summary>
        /// <param name="employeeId">The ID of the employee to delete.</param>
        public static void DeleteEmployeeById(int employeeId)
        {
            var employees = ReadFromFile().ToList();

            int indexToDelete = employees.FindIndex(e => e.EmployeeID == employeeId);

            if (indexToDelete != -1)
            {
                employees.RemoveAt(indexToDelete);
                WriteToFile(employees.ToArray());
            }
            else
            {
                Console.WriteLine("Employee ID not found.");
            }
        }

        /// <summary>
        /// Writes employee data to the file.
        /// </summary>
        /// <param name="employees">An array of Employee objects to write to the file.</param>
        public static void WriteToFile(Employee[] employees)
        {
            try
            {
                string[] lines = employees.Select(e =>
                    $"{e.EmployeeID}\t{e.EmployeeName}\t{e.EmailId}\t{e.PhoneNumber}\t{e.JobTitle}\t{e.IsActive}").ToArray();

                File.WriteAllLines(filePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Downloads the file containing employee data.
        /// </summary>
        /// <returns>An HttpResponseMessage containing the file for download.</returns>
        public static HttpResponseMessage DownloadFile()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new Exception("File Not Found");
                }
                byte[] fileBytes = File.ReadAllBytes(filePath);

                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(fileBytes);
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "EmployeeData.txt"
                };
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}