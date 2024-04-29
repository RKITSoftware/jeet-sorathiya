using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Advance_C__FinalDemo.Models.DTO
{
    /// <summary>
    /// Represents a movie model
    /// </summary>
    public class DTOMOV01
    {
        /// <summary>
        /// Gets or sets the ID of the movie
        /// </summary>
        [JsonProperty("V01101")]
        public int V01F01 { get; set; }

        /// <summary>
        /// Gets or sets the title of the movie
        /// </summary>
        [JsonProperty("V01102")]
        [Required(ErrorMessage = "Movie title is required.")]
        public string V01F02 { get; set; }

        /// <summary>
        /// Gets or sets the release date of the movie
        /// </summary>
        [JsonProperty("V01103")]
        public DateTime V01F03 { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the category of the movie
        /// </summary>
        [JsonProperty("V01104")]
        public int V01F04 { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the director of the movie
        /// </summary>
        [JsonProperty("V01105")]
        public int V01F05 { get; set; }
    }
}