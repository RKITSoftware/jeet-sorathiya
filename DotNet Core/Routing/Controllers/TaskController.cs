using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Routing.Models;

namespace Routing.Controllers
{
    /// <summary>
    /// TaskController for Performing CRUD Opratrion on List of TodoItem
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    
    public class TaskController : ControllerBase
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

        /// <summary>
        /// Get All Task, Order is 1
        /// </summary>
        /// <returns>List of TodoItems</returns>
        [HttpGet(Name = "GetAllTasks",Order = 1)]
        public ActionResult<IEnumerable<TodoItem>> Get()
        {
            return Ok(todoItems);
        }

        /// <summary>
        /// Add New Task into TodoItem
        /// </summary>
        /// <param name="newTask">object of TodoItem that have new Task</param>
        /// <returns>Appropriate StatusCode with Message</returns>
        [HttpPost(Name = "AddTask")]
        public ActionResult Post(TodoItem newTask)
        {
            todoItems.Add(newTask);
            return StatusCode(201,"Task Added");
        }

        /// <summary>
        /// Get TodoItem using ID
        /// </summary>
        /// <param name="id">Id of TodoItem</param>
        /// <returns>TodoItem of that ID</returns>
        [HttpGet("{id}", Name = "GetTaskById")]
        public ActionResult<TodoItem> GetById(int id)
        {
            var task = todoItems.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound("Task not found");
            }
            return Ok(task);
        }

        /// <summary>
        /// Update Task
        /// </summary>
        /// <param name="id">Id of TodoItem</param>
        /// <param name="updatedTask">object of TodoItem that have new Task</param>
        /// <returns>Appropriate Message based on Task Update or not</returns>
        [HttpPut("{id}", Name = "UpdateTask")]
        public ActionResult Put(int id, TodoItem updatedTask)
        {
            var task = todoItems.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound("Task not found");
            }

            task.Name = updatedTask.Name;
            task.IsComplete = updatedTask.IsComplete;

            return Ok("Task updated successfully");
        }

        /// <summary>
        /// Delete Particular Task From TodoList
        /// </summary>
        /// <param name="id">Id of TodoItem</param>
        /// <returns>Appropriate Message based on Task deleted or not</returns>
        [HttpDelete("{id}", Name = "DeleteTask")]
        public ActionResult Delete(int id)
        {
            var task = todoItems.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound("Task not found");
            }

            todoItems.Remove(task);

            return Ok("Task deleted successfully");
        }

    }
}
