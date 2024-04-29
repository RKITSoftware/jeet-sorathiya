using DataBase_With_CRUD.Models.Enum;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DataBase_With_CRUD.Models.DTO
{
    public class DTOEMP01
    {
        /// <summary>
        /// Gets or sets the primary key for EmployeeId as EMP01
        /// </summary>
        [JsonProperty("P01101")]
        public int P01F01 { get; set; }

        /// <summary>
        /// Gets or sets the value of the EmployeeName as P01F02 field
        /// </summary>
        [Required(ErrorMessage = "EmployeeName is required")]
        [JsonProperty("P01102")]
        public string P01F02 { get; set; }

        /// <summary>
        /// Gets or sets the value of the EmployeeRole as P01F03 field
        /// </summary>
        [EnumDataType(typeof(EnmRole), ErrorMessage = "Invalid EmployeeRole")]
        [JsonProperty("P01103")]
        public string P01F03 { get; set; }

        /// <summary>
        /// Gets or sets the value of the IsActive as P01F04 field, representing a boolean value
        /// </summary>
        [JsonProperty("P01104")]
        public bool P01F04 { get; set; }
    }
}