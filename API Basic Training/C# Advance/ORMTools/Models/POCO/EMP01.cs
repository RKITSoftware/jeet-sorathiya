using ServiceStack.DataAnnotations;

namespace ORMTools.Models
{
    /// <summary>
    /// Represents the EMP01 table entity.
    /// </summary>
    public class EMP01
    {
        /// <summary>
        /// Gets or sets the auto-incremented primary key for EmployeeId.
        /// </summary>
        public int P01F01 { get; set; }

        /// <summary>
        /// Gets or sets the value of the EmployeeName field.
        /// </summary>
        public string P01F02 { get; set; }

        /// <summary>
        /// Gets or sets the value of the Employee-Role field.
        /// </summary>
        public string P01F03 { get; set; }

        /// <summary>
        /// Gets or sets the value of the Is-Active field.
        /// </summary>
        public bool P01F04 { get; set; }
    }
}