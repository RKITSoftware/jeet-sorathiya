using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using LINQ.Models;

namespace LINQ
{
    /// <summary>
    /// Provides methods for employee
    /// </summary>
    public class EmployeData
    {
        /// <summary>
        /// Creates and returns a DataTable containing employee data
        /// </summary>
        /// <returns>A DataTable with columns for Id, Name, Age, and Department</returns>
        public DataTable CreateEmployeeTable()
        {
            DataTable employeeTable = new DataTable();
            employeeTable.Columns.Add("Id", typeof(int));
            employeeTable.Columns.Add("Name", typeof(string));
            employeeTable.Columns.Add("Age", typeof(int));
            employeeTable.Columns.Add("Department", typeof(string));

            employeeTable.Rows.Add(1, "Jeet", 21, "Developer");
            employeeTable.Rows.Add(2, "Tony", 45, "Developer");
            employeeTable.Rows.Add(3, "Steav", 100, "HR");
            employeeTable.Rows.Add(4, "SpiderMan", 18, "Developer");

            return employeeTable;
        }

        /// <summary>
        /// Creates and returns a List of Employee objects
        /// </summary>
        /// <returns>List containing Employee objects</returns>
        public List<Employee> CreateEmployeesList()
        {
            List<Employee> employeesList = new List<Employee>
           {
               new Employee {Id = 1, Name = "Jeet-Sorathiya", Age = 21, Department = "Developer"},
               new Employee {Id = 2, Name = "Tony-Stark", Age = 45, Department = "Developer"},
               new Employee {Id = 3, Name = "Steav-Roger", Age = 100, Department = "HR"},
               new Employee {Id = 4, Name = "SpiderMan", Age = 18, Department = "Developer"}
           };

            return employeesList;
        }
        /// <summary>
        /// Filters employees based on age
        /// </summary>
        /// <param name="employees">The list of employees</param>
        /// <param name="age">age for filtering</param>
        /// <returns>IEnumerable employees</returns>
        public IEnumerable<Employee> FilterEmployeesByAge(IEnumerable<Employee> employees, int age)
        {
            return employees.Where(emp => emp.Age > age);
        }

        /// <summary>
        /// Finds and returns youngest employee
        /// </summary>
        /// <param name="employees">The list of employees</param>
        /// <returns>youngest employee</returns>
        public Employee FindYoungestEmployee(IEnumerable<Employee> employees)
        {
            return employees.OrderBy(emp => emp.Age).FirstOrDefault();
        }

        /// <summary>
        /// unique departments from the provided employees
        /// </summary>
        /// <param name="employees">The list of employees</param>
        /// <returns>IEnumerable with unique department names</returns>
        public IEnumerable<string> GetUniqueDepartments(IEnumerable<Employee> employees)
        {
            return employees.Select(emp => emp.Department).Distinct();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeData objOfEmployeData = new EmployeData();

            DataTable employeesDataTable = objOfEmployeData.CreateEmployeeTable();

            List<Employee> employeesDataList = objOfEmployeData.CreateEmployeesList();

            // LINQ Query on DataTable - Filtering
            var dataTableQuery = from row in employeesDataTable.AsEnumerable()
                                 where row.Field<int>("Age") > 25
                                 orderby row.Field<string>("Name")
                                 select new Employee
                                 {
                                     Id = row.Field<int>("Id"),
                                     Name = row.Field<string>("Name"),
                                     Age = row.Field<int>("Age"),
                                     Department = row.Field<string>("Department")
                                 };

            Console.WriteLine("DataTable Query\n");
            foreach (var result in dataTableQuery)
            {
                Console.WriteLine($"Id : {result.Id}, Name : {result.Name}, Age : {result.Age}, Department : {result.Department}");
            }

            // LINQ Query on List - Grouping and Aggregation
            var listQuery = from employee in employeesDataList
                            group employee by employee.Department into departmentGroup
                            select new
                            {
                                Department = departmentGroup.Key,
                                AverageAge = departmentGroup.Average(e => e.Age),
                                TotalEmployees = departmentGroup.Count()
                            };
            Console.WriteLine("\nList Query\n");
            foreach (var result in listQuery)
            {
                Console.WriteLine($"Department : {result.Department}, AverageAge : {result.AverageAge}, TotalEmployees : {result.TotalEmployees}");
            }

            // filter employee based on age
            int age = 20;
            var filterEmployee = objOfEmployeData.FilterEmployeesByAge(employeesDataList, age);
            Console.WriteLine("\nFilter Employee:\n");
            foreach (var result in filterEmployee)
            {
                Console.WriteLine($"Id : {result.Id}, Name : {result.Name}, Age : {result.Age}, Department : {result.Department}");
            }

            // find youngest employee
            var youngestEmployee = objOfEmployeData.FindYoungestEmployee(employeesDataList);
            Console.WriteLine("\nYoungest Employee:\n");
            Console.WriteLine($"Id : {youngestEmployee.Id}, Name : {youngestEmployee.Name}, Age : {youngestEmployee.Age}, Department : {youngestEmployee.Department}");


            // give unique department
            var uniqueDepartments = objOfEmployeData.GetUniqueDepartments(employeesDataList);
            Console.WriteLine("\nUnique Departments:\n");
            foreach (var department in uniqueDepartments)
            {
                Console.WriteLine(department);
            }
        }
    }
}
