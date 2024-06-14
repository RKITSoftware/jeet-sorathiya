using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Advance_C__FinalDemo.Models.Enum;

namespace Advance_C__FinalDemo.Models.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for user information.
    /// </summary>
    public class DTOUSR01
    {
        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        [JsonProperty("R01101")]
        [Required(ErrorMessage = "Id is required.")]
        public int R01F01 { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        [JsonProperty("R01102")]
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100, ErrorMessage = "Username cannot exceed 100 characters.")]
        public string R01F02 { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        [JsonProperty("R01103")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string R01F03 { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        [JsonProperty("R01104")]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password should be between 6 and 100 characters.")]
        public string R01F04 { get; set; }

        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        [JsonProperty("R01105")]
        [Required(ErrorMessage = "Role is required.")]
        [EnumDataType(typeof(EnmRole), ErrorMessage = "Invalid role.")]
        public string R01F05 { get; set; }
    }
}
