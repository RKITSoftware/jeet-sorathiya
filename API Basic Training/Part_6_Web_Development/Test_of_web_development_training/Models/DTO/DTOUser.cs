using System.ComponentModel.DataAnnotations;
using Test_of_web_development_training.Models.Enum;

namespace Test_of_web_development_training.Models.DTO
{
    public class DTOUser
    {
        /// <summary>
        /// Gets or sets the unique id of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Password must be at least 4 characters.")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the role of the user (e.g., Admin, Subscriber, NonSubscriber).
        /// </summary>
        [Required(ErrorMessage = "Role is required.")]
        [EnumDataType(typeof(EnmRole), ErrorMessage = "Invalid role.")]
        public string Role { get; set; }
    }
}