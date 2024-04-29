using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using ORMTools.Models.Enum;

namespace ORMTools.Models.DTO
{
    public class DTOEMP01
    {
        /// <summary>
        /// Gets or sets the auto-incremented primary key for EmployeeId.
        /// </summary>       
        [JsonProperty("P01101")]
        public int P01F01 { get; set; }

        /// <summary>
        /// Gets or sets the value of the EmployeeName field.
        /// </summary>
        [Required(ErrorMessage = "Employee Name is required.")]
        [StringLength(20, ErrorMessage = "Employee Name cannot exceed 20 characters.")]
        [JsonProperty("P01102")]
        public string P01F02 { get; set; }

        /// <summary>
        /// Gets or sets the value of the Employee-Role field.
        /// </summary>
        [Required(ErrorMessage = "Role is required.")]
        [EnumDataType(typeof(EnmRole), ErrorMessage = "Invalid role")]
        [JsonProperty("P01103")]
        public string P01F03 { get; set; }

        /// <summary>
        /// Gets or sets the value of the Is-Active field.
        /// </summary>
        [JsonProperty("P01104")]
        public bool P01F04 { get; set; }
    }
}
