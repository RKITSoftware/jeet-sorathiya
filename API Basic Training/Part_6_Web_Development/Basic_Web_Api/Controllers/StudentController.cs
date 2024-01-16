using Basic_Web_Api.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Basic_Web_Api.Controllers
{
    /// <summary>
    /// Controller for managing student information through Web API.
    /// </summary>
    public class StudentController : ApiController
    {
        // Static list to store student data.
        private static List<Student> studentList = new List<Student>
        {
            new Student{studentID = 1, studentName = "Jeet", IsActive = true},
            new Student{studentID = 2, studentName = "Tony Stark", IsActive=false},
        };

        /// <summary>
        /// Gets the list of all students.
        /// </summary>
        [HttpGet]
        public List<Student> Get()
        {
            return studentList;
        }

        /// <summary>
        /// Gets a specific student by ID.
        /// </summary>
        [HttpGet]
        public Student Get(int id)
        {
            return studentList.Find(student => student.studentID == id);
        }

        /// <summary>
        /// Adds a new student to the list.
        /// </summary>
        [HttpPost]
        public void Post(Student student)
        {
            studentList.Add(student);
        }

        /// <summary>
        /// Deletes a student by ID.
        /// </summary>
        [HttpDelete]
        public void Delete(int id)
        {
            var deleteStudent = studentList.Find(student => student.studentID == id);
            if (deleteStudent != null)
            {
                studentList.Remove(deleteStudent);
            }
        }

        /// <summary>
        /// Updates an existing student by ID.
        /// </summary>
        [HttpPut]
        public void Put(int id, Student newStudent)
        {
            var currentStudent = studentList.Find(student => student.studentID == id);
            if (currentStudent != null)
            {
                currentStudent.studentName = newStudent.studentName;
                currentStudent.IsActive = newStudent.IsActive;
            }
        }
    }
}
