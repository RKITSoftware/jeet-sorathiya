namespace Test_of_web_development_training.Models
{
    /// <summary>
    /// Represents a Marvel character in Version 1.
    /// </summary>
    public class MarvelCharacterV1
    {
        // A static field to keep track of the last assigned character ID
        private static int lastAssignedId = 0;

        /// <summary>
        /// Gets or sets the unique id of the character.
        /// </summary>
        public int CharacterId { get; set; }

        /// <summary>
        /// Gets or sets the real name of the character.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the superhero name of the character.
        /// </summary>
        public string SuperheroName { get; set; }

        /// <summary>
        /// Gets or sets the role of the character (e.g., Superhero, Villain).
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MarvelCharacterV1"/> class.
        /// </summary>
        public MarvelCharacterV1()
        {
            // Assign a unique ID to the character upon creation
            CharacterId = ++lastAssignedId;
        }
    }
}