using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Advance_C__FinalDemo.Models.DTO
{
    /// <summary>
    /// Represents a category model
    /// </summary>
    public class DTOCAT01
    {
        /// <summary>
        /// Gets or sets the ID for the category
        /// </summary>
        [JsonProperty("T01101")]
        public int T01F01 { get; set; }

        /// <summary>
        /// Gets or sets the name of the category
        /// </summary>
        [JsonProperty("T01102")]
        [Required(ErrorMessage = "Category name is required.")]
        public string T01F02 { get; set; }
    }
}