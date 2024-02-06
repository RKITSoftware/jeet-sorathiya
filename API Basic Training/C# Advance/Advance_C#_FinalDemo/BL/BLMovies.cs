using Advance_C__FinalDemo.Models;
using Google.Protobuf.WellKnownTypes;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Advance_C__FinalDemo.BL
{
    public class BLMovies
    {
        // Retrieve IDbConnectionFactory from the application context
        private readonly IDbConnectionFactory _dbFactory;

       public BLMovies()
        {
            _dbFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;

            if(_dbFactory != null ) 
            {
                throw new Exception("IDbConnectionFactory not found"); 
            }
        }

        public List<MOV01> GetAll()
        {
            using(var db = _dbFactory.OpenDbConnection())
            {
                List<MOV01> movies = db.Select<MOV01>();
                return movies;
            }
        }

        public bool Add(MOV01 newEmployee)
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    db.Insert(newEmployee);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message); 
                return false; 
            }
            return true;
        }

        public bool Update(MOV01 newEmployee)
        {
            try
            {
                using(var db = _dbFactory.OpenDbConnection())
                {
                   if(newEmployee != null)
                    {
                        db.Update(newEmployee);
                    }
                   else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                using(var db = _dbFactory.OpenDbConnection())
                {
                    db.DeleteById<MOV01>(id);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}