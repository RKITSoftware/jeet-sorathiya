using System.Collections.Generic;

namespace Test_of_web_development_training.Models
{
    /// <summary>
    /// Represents a Marvel character in Version 2 with additional details.
    /// </summary>
    public class MarvelCharacterV2
    {
        // A static field to keep track of the last assigned character ID
        private static int lastAssignedId = 0;

        /// <summary>
        /// Gets or sets the unique id of the character.
        /// </summary>
        public int CharacterId { get; set; }

        /// <summary>
        /// Gets or sets the full name of the character.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the superhero name of the character.
        /// </summary>
        public string HeroName { get; set; }

        /// <summary>
        /// Gets or sets the list of abilities the character possesses.
        /// </summary>
        public List<string> Abilities { get; set; }

        /// <summary>
        /// Gets or sets the birthplace of the character.
        /// </summary>
        public string Birthplace { get; set; }

        /// <summary>
        /// Gets or sets the team affiliation of the character.
        /// </summary>
        public string Team { get; set; }

        /// <summary>
        /// Gets or sets the role of the character (e.g., Superhero, Villain).
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MarvelCharacterV2"/> class.
        /// </summary>
        public MarvelCharacterV2()
        {
            // Assign a unique ID to the character upon creation
            CharacterId = ++lastAssignedId;
        }
    }
}