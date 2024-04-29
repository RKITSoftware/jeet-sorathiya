namespace Test_of_web_development_training.Models.POCO
{
    /// <summary>
    /// Represents a Marvel character in Version 1.
    /// </summary>
    public class MarvelCharacterV1
    {
      
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
        
    }
}