using Employees;
using System;
using System.Net.Http.Headers;

namespace ClassDemo
{
    #region Program
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating an instance of the Employee class
            Employee objofEmployee = new Employee();

            // Performing developer-related tasks
            objofEmployee.DeveloperLogin();
            objofEmployee.DeveloperTask();
            objofEmployee.DeveloperLogout();

            // Performing customer support-related tasks
            objofEmployee.CustomerSupportLogin();
            objofEmployee.CustomerSupportTask();
            objofEmployee.CustomerSupportLogout();
        }
    }
    #endregion
}
