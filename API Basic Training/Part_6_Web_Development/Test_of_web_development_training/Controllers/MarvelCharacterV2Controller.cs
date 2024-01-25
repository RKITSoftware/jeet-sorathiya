using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Test_of_web_development_training.DAL;
using Test_of_web_development_training.Models;
using Test_of_web_development_training.SEC__Security;

namespace Test_of_web_development_training.Controllers
{
    /// <summary>
    /// Controller for managing Marvel characters (Version 2).
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "GET")]
    [RoutePrefix("api/V2/MarvelCharacter")]
    [BasicAuthenticationAttribute]
    public class MarvelCharacterV2Controller : ApiController
    {
        private static string etag = Guid.NewGuid().ToString();
        private static object cachedData;

        // Static list to store Marvel characters
        static List<MarvelCharacterV2> marvelCharacterList = new List<MarvelCharacterV2>
            {
                new MarvelCharacterV2 {FullName = "Tony Stark", HeroName = "Iron Man", Abilities = new List<string> { "Powered Armor", "Genius-level intellect" }, Birthplace = "Earth", Team = "Avengers", Role = "Superhero" },
                new MarvelCharacterV2 {FullName = "Steve Rogers", HeroName = "Captain America", Abilities = new List<string> { "Superhuman strength", "Enhanced agility" }, Birthplace = "Earth", Team = "Avengers", Role = "Superhero" },
                new MarvelCharacterV2 {FullName = "Bruce Banner", HeroName = "Hulk", Abilities = new List<string> { "Superhuman strength", "Regenerative healing factor" }, Birthplace = "Earth", Team = "Avengers", Role = "Superhero" },
                new MarvelCharacterV2 {FullName = "Thor Odinson", HeroName = "Thor", Abilities = new List<string> { "God-like strength", "Control over lightning" }, Birthplace = "Asgard", Team = "Avengers", Role = "Superhero" },
                new MarvelCharacterV2 {FullName = "Natasha Romanoff", HeroName = "Black Widow", Abilities = new List<string> { "Master martial artist", "Espionage expert" }, Birthplace = "Earth", Team = "Avengers", Role = "Superhero" },
                new MarvelCharacterV2 {FullName = "Clint Barton", HeroName = "Hawkeye", Abilities = new List<string> { "Master archer", "Exceptional hand-to-hand combatant" }, Birthplace = "Earth", Team = "Avengers", Role = "Superhero" },
                new MarvelCharacterV2 {FullName = "Loki Laufeyson", HeroName = "Loki", Abilities = new List<string> { "Illusions", "Shape-shifting" }, Birthplace = "Asgard", Team = "Villains", Role = "Villain" },
                new MarvelCharacterV2 {FullName = "Thanos", HeroName = "Thanos", Abilities = new List<string> { "Superhuman strength", "Genius-level intellect" }, Birthplace = "Titan", Team = "Villains", Role = "Villain" },
                new MarvelCharacterV2 {FullName = "Peter Parker", HeroName = "Spider-Man", Abilities = new List<string> { "Wall-crawling", "Spider-sense" }, Birthplace = "Earth", Team = "Avengers", Role = "Superhero" },
                new MarvelCharacterV2 {FullName = "Scott Lang", HeroName = "Ant-Man", Abilities = new List<string> { "Size manipulation", "Control of ants" }, Birthplace = "Earth", Team = "Avengers", Role = "Superhero" }

            };

        // Cache manager instance for caching responses
        private static CacheManager cacheManager = new CacheManager();

        /// <summary>
        /// Fetches data from the marvelCharacterList or returns a message if the list is empty.
        /// </summary>
        /// <returns>List of Marvel characters or a message if the list is empty.</returns>
        private object FetchData()
        {
            if (marvelCharacterList.Count == 0)
            {
                return "No any Character";
            }
            return marvelCharacterList;
        }
        #region Get Methods

        /// <summary>
        /// Retrieves a list of Marvel characters with caching support.
        /// </summary>
        [HttpGet]
        [Route("ListOfCharacters")]
        [BasicAuthorization(Roles = "Admin,Subscriber,NonSubscriber")]
        public HttpResponseMessage ListOfCharacters()
        {
            return cacheManager.GetCachedResponse(Request, FetchData);

        }

        /// <summary>
        /// Retrieves information about a specific Marvel character by ID.
        /// </summary>
        [HttpGet]
        [Route("CharacterInfo/{id}")]
        [BasicAuthorizationAttribute(Roles = "Admin,Subscriber")]
        public IHttpActionResult CharacterInfo(int id)
        {
            var response = marvelCharacterList.Find(chr => chr.CharacterId == id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);

        }

        /// <summary>
        /// Retrieves a list of Marvel superheroes.
        /// </summary>
        [HttpGet]
        [Route("ListOfSuperHeros")]
        [BasicAuthorizationAttribute(Roles = "Admin,Subscriber")]
        public IHttpActionResult ListOfSuperHeros()
        {
            List<MarvelCharacterV2> superHeros = marvelCharacterList.FindAll(chr => chr.Role.Equals("Superhero"));
            if (superHeros.Count == 0)
            {
                return NotFound();
            }
            return Ok(superHeros);
        }

        /// <summary>
        /// Retrieves a list of Marvel villains.
        /// </summary>
        [HttpGet]
        [Route("ListOfVillain")]
        [BasicAuthorizationAttribute(Roles = "Admin,Subscriber")]
        public IHttpActionResult ListOfVillain()
        {
            List<MarvelCharacterV2> Villains = marvelCharacterList.FindAll(chr => chr.Role.Equals("Villain"));
            if (Villains.Count == 0)
            {
                return NotFound();
            }
            return Ok(Villains);
        }
        #endregion

        #region Post Method

        /// <summary>
        /// Adds a new Marvel character.
        /// </summary>
        [HttpPost]
        [Route("AddNewCharacter")]
        [BasicAuthorization(Roles = "Admin")]
        public IHttpActionResult AddNewCharacter(MarvelCharacterV2 character)
        {
            marvelCharacterList.Add(character);
            return Ok(marvelCharacterList);
        }
        #endregion

        #region Put Method

        /// <summary>
        /// Updates information about a specific Marvel character by ID.
        /// </summary>
        [HttpPut]
        [Route("UpdateCharacterInfo/{id}")]
        [BasicAuthorization(Roles = "Admin")]
        public IHttpActionResult UpdateCharacterInfo(int id, MarvelCharacterV2 character)
        {
            var targetCharacter = marvelCharacterList.Find(chr => chr.CharacterId == id);
            if (targetCharacter == null)
            {
                return NotFound();
            }
            targetCharacter.FullName = character.FullName;
            targetCharacter.HeroName = character.HeroName;
            targetCharacter.Abilities = character.Abilities;
            targetCharacter.Birthplace = character.Birthplace;
            targetCharacter.Team = character.Team;
            targetCharacter.Role = character.Role;
            return Ok(targetCharacter);
        }
        #endregion

        #region Delete Method

        /// <summary>
        /// Deletes a Marvel character by ID.
        /// </summary>
        [HttpDelete]
        [Route("DeleteCharacter/{id}")]
        [BasicAuthorization(Roles = "Admin")]
        public IHttpActionResult DeleteCharacter(int id)
        {
            var targetCharacter = marvelCharacterList.Find(chr => chr.CharacterId == id);
            if (targetCharacter == null)
            {
                return NotFound();
            }
            marvelCharacterList.Remove(targetCharacter);
            return Ok(targetCharacter);
        }
        #endregion
    }
}
