using HTTPcaching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTTPcaching.BL
{
    public class BLEmployee
    {
        static readonly List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Jeet"},
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

        public IEnumerable<Employee> GetAll()
        {
            return employees;
        }

    }
}