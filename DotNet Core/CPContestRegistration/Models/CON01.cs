using System.ComponentModel.DataAnnotations;

namespace CPContestRegistration.Models
{
    /// <summary>
    /// Represents a contest registration
    /// </summary>
    public class CON01
    {
        /// <summary>
        /// Gets or sets the ID of the contest.
        /// </summary>
        [Required]
        public int N01F01 { get; set; }

        /// <summary>
        /// Gets or sets the name of the contest.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string N01F02 { get; set; }

        /// <summary>
        /// Gets or sets the start date and time of the contest.
        /// </summary>
        [Required]
        public DateTime N01F03 { get; set; }

        /// <summary>
        /// Gets or sets the end date and time of the contest.
        /// </summary>
        [Required]
        public DateTime N01F04 { get; set; }
    }
}
