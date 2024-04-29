using System.ComponentModel.DataAnnotations;
using Test_of_web_development_training.Models.Enum;

namespace Test_of_web_development_training.Models.DTO
{
    public class DTOMarvelCharacterV1
    {
        /// <summary>
        /// Gets or sets the unique id of the character.
        /// </summary>
        public int CharacterId { get; set; }

        /// <summary>
        /// Gets or sets the real name of the character.
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the superhero name of the character.
        /// </summary>
        [Required(ErrorMessage = "Superhero name is required.")]
        public string SuperheroName { get; set; }

        /// <summary>
        /// Gets or sets the role of the character (e.g., Superhero, Villain).
        /// </summary>
        [Required(ErrorMessage = "Role is required.")]
        [EnumDataType(typeof(EnmRole), ErrorMessage = "Invalid role.")]
        public string Role { get; set; }
    }
}