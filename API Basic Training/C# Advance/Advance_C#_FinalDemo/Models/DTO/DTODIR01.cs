using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Advance_C__FinalDemo.Models.DTO
{
    /// <summary>
    /// Represents a director model
    /// </summary>
    public class DTODIR01
    {
        /// <summary>
        /// Gets or sets the ID the director
        /// </summary>
        [JsonProperty("R01101")]
        public int R01F01 { get; set; }

        /// <summary>
        /// Gets or sets the name of the director
        /// </summary>
        [JsonProperty("R01102")]
        [Required(ErrorMessage = "Director name is required.")]
        public string R01F02 { get; set; }
    }
}