using System.ComponentModel.DataAnnotations;
using Test_of_web_development_training.Models.Enum;

namespace Test_of_web_development_training.Models.DTO
{
    public class DTOMarvelCharacterV2
    {
        /// <summary>
        /// Gets or sets the unique id of the character.
        /// </summary>
        public int CharacterId { get; set; }

        /// <summary>
        /// Gets or sets the full name of the character.
        /// </summary>
        [Required(ErrorMessage = "Full name is required.")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the superhero name of the character.
        /// </summary>
        [Required(ErrorMessage = "Hero name is required.")]
        public string HeroName { get; set; }

        /// <summary>
        /// Gets or sets the list of abilities the character possesses.
        /// </summary>
        [Required(ErrorMessage = "Abilities are required.")]
        [MinLength(1, ErrorMessage = "At least one ability must be specified.")]
        public string[] Abilities { get; set; }

        /// <summary>
        /// Gets or sets the birthplace of the character.
        /// </summary>
        public string Birthplace { get; set; }

        /// <summary>
        /// Gets or sets the team affiliation of the character.
        /// </summary>
        public string Team { get; set; }

        /// <summary>
        /// Gets or sets the role of the character
        /// </summary>
        [Required(ErrorMessage = "Role is required.")]
        [EnumDataType(typeof(EnmRole), ErrorMessage = "Invalid role")]
        public string Role { get; set; }
    }
}