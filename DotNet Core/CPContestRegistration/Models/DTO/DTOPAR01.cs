using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CPContestRegistration.Models.DTO
{
    public class DTOPAR01
    {
        /// <summary>
        /// Gets or sets the ID of the participant.
        /// </summary>
        [Required]
        [JsonProperty("R01101")]
        public int R01F01 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user
        /// </summary>
        [Required]
        [JsonProperty("R01102")]
        public int R01F02 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the contest
        /// </summary>
        [Required]
        [JsonProperty("R01103")]
        public int R01F03 { get; set; }

        /// <summary>
        /// Gets or sets the registration date and time of the participant.
        /// </summary>
        [Required]
        [JsonProperty("R01104")]
        public DateTime R01F04 { get; set; }
    }
}
