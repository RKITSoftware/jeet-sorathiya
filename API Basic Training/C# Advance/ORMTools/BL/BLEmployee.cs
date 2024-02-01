using ORMTools.Models;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMTools.BL
{
    /// <summary>
    /// Business logic class for managing EMP01 (Employee) data.
    /// </summary>
    public static class BLEmployee
    {
        // Retrieve IDbConnectionFactory from the application context
        private static readonly IDbConnectionFactory _dbFactory;

        static BLEmployee()
        {
            _dbFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;

            if ( _dbFactory == null )
            {
                throw new Exception("IDbConnectionFactory not found");
            }
        }

        /// <summary>
        /// Retrieves all employees from the database.
        /// </summary>
        /// <returns>List of employees</returns>
        public static List<EMP01> GetAll()
        {
            using(var db = _dbFactory.OpenDbConnection())
            {
                var employees = db.Select<EMP01>();

                return employees;
            }
        }

        /// <summary>
        /// Retrieves an employee by ID from the database.
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>Employee with the specified ID</returns>
        public static EMP01 Get(int id)
        {
            using(var db = _dbFactory.OpenDbConnection())
            {
                var employee = db.SingleById<EMP01>(id);
                return employee;
            }
        }

        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="employee">Employee data to be added</param>
        public static void Add(EMP01 employee)
        {
            using(var db = _dbFactory.OpenDbConnection())
            {
                db.Insert(employee);
            }
        }

        /// <summary>
        /// Deletes an employee by ID from the database.
        /// </summary>
        /// <param name="id">Employee ID</param>
        public static void Delete(int id)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                db.DeleteById<EMP01>(id);
            }
        }

        /// <summary>
        /// Updates an existing employee in the database.
        /// </summary>
        /// <param name="employee">Updated employee data</param>
        public static void Update(EMP01 employee)
        {
            using (var db = _dbFactory.OpenDbConnection())
            { 

                if(employee != null)
                {
                    db.Update(employee);
                }
            }
        }
    }
}