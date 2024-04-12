namespace Basic_Web_Api.Models
{
    /// <summary>
    /// Represents a student entity with basic information.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets the unique ID for the student.
        /// </summary>
        public int studentID { get; set; }

        /// <summary>
        /// Gets or sets the name of the student.
        /// </summary>
        public string studentName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the student is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}