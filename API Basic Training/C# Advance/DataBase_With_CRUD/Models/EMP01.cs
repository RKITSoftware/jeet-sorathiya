namespace DataBase_With_CRUD.Models
{
    /// <summary>
    /// Represents the Employee as EMP01 table  entity
    /// </summary>
    public class EMP01
    {
        /// <summary>
        /// Gets or sets the primary key for EmployeeId as EMP01
        /// </summary>
        public int P01F01 { get; set; }

        /// <summary>
        /// Gets or sets the value of the EmployeeName as P01F02 field
        /// </summary>
        public string P01F02 { get; set; }

        /// <summary>
        /// Gets or sets the value of the EmployeeRole as P01F03 field
        /// </summary>
        public string P01F03 { get; set; }

        /// <summary>
        /// Gets or sets the value of the IsActive as P01F04 field, representing a boolean value
        /// </summary>
        public bool P01F04 { get; set; }
    }
}