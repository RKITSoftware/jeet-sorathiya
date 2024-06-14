
namespace CPContestRegistration.Models.POCO
{
    /// <summary>
    /// Represents a participant registration 
    /// </summary>
    public class PAR01
    {
        /// <summary>
        /// Gets or sets the ID of the participant.
        /// </summary>
        public int R01F01 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user
        /// </summary>
        public int R01F02 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the contest
        /// </summary>
        public int R01F03 { get; set; }

        /// <summary>
        /// Gets or sets the registration date and time of the participant.
        /// </summary>
        public DateTime R01F04 { get; set; }
    }
}
