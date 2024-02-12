using CacheClass.Models;
using System;
using System.Collections.Generic;
using System.Web.Caching;

namespace CacheClass.BL
{
    public class BLEmployee
    {
        // Static list of employees
        private static List<Employee> _lstEmployee;

        // Cache instance to store the list of employees
        private static Cache _cache;

        // Static constructor to initialize the static list and cache
        static BLEmployee()
        {
            _cache = new Cache();
            _lstEmployee = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Jeet" },
                new Employee { Id = 2, Name = "Tony Stark" },
                new Employee { Id = 3, Name = "Spider-Man" },
                new Employee { Id = 4, Name = "Hulk" },
                new Employee { Id = 5, Name = "Thor" },
                new Employee { Id = 6, Name = "Black Widow" },
                new Employee { Id = 7, Name = "Captain America" },
                new Employee { Id = 8, Name = "Doctor Strange" },
                new Employee { Id = 9, Name = "Black Panther" },
                new Employee { Id = 10, Name = "Captain Marvel" }
            };
        }

        /// <summary>
        /// Retrieves the list of employees, either from cache or initializes it and adds to the cache
        /// </summary>
        /// <returns>The list of employees</returns>
        public List<Employee> EmployeesList()
        {
            // Attempt to retrieve the list of employees from the cache
            List<Employee> employees = _cache.Get("_lstEmployee") as List<Employee>;

            if (employees != null)
            {
                // Return the cached list if available
                return employees;
            }

            // If the list is not in the cache, add it to the cache with a 10-second expiration time
            TimeSpan ts = new TimeSpan(0, 0, 10);
            _cache.Add("_lstEmployee", _lstEmployee, null, DateTime.MaxValue, ts, CacheItemPriority.Default, null);

            // Return the list of employees
            return _lstEmployee;
        }
    }
}