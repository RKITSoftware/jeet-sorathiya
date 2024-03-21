using Microsoft.AspNetCore.Mvc;
using Routing.Models;

namespace Routing.Controllers
{
    /// <summary>
    /// HomeController for Managed TodoList
    /// </summary>
    //[Route("api/[controller]")]
    //[ApiController]
    public class HomeController : ControllerBase
    {
        //Task data
        public static List<TodoItem> todoItems = new List<TodoItem>
           {
                new TodoItem { Id = 1, Name = "C#", IsComplete = true },
                new TodoItem { Id = 2, Name = "Database Management System", IsComplete = true },
                new TodoItem { Id = 3, Name = "Web Development", IsComplete = false },
                new TodoItem { Id = 4, Name = "C# Advance", IsComplete = false },
                new TodoItem { Id = 5, Name = "DotNet Core", IsComplete = false }
            };

        // [HttpGet(Name = "GetData")]
        // [ProducesResponseType(200,Type = typeof(IEnumerable<TodoItem>))]
        /// <summary>
        /// Get All TodoList of Task
        /// </summary>
        /// <returns>Return List of TodoItem</returns>
        public ActionResult<IEnumerable<TodoItem>> Get()
        {
            return Ok(todoItems);
        }

    }
}
