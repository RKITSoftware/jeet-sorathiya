using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CPContestRegistration.Models.DTO
{
    public class DTOUSE01
    {
        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        [Required]
        [JsonProperty("E01101")]
        public int E01F01 { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        [Required]
        [JsonProperty("E01102")]
        public string E01F02 { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        [Required]
        [JsonProperty("E01103")]
        public string E01F03 { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        [Required]
        [JsonProperty("E01104")]
        public string E01F04 { get; set; }
    }
}
