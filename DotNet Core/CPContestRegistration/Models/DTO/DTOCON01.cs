using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CPContestRegistration.Models.DTO
{
    public class DTOCON01
    {
        /// <summary>
        /// Gets or sets the ID of the contest.
        /// </summary>
        [Required]
        [JsonProperty("N01101")]
        public int N01F01 { get; set; }

        /// <summary>
        /// Gets or sets the name of the contest.
        /// </summary>
        [Required]
        [StringLength(50)]
        [JsonProperty("N01102")]
        public string N01F02 { get; set; }

        /// <summary>
        /// Gets or sets the start date and time of the contest.
        /// </summary>
        [Required]
        [JsonProperty("N01103")]
        public DateTime N01F03 { get; set; }

        /// <summary>
        /// Gets or sets the end date and time of the contest.
        /// </summary>
        [Required]
        [JsonProperty("N01104")]
        public DateTime N01F04 { get; set; }
    }
}
