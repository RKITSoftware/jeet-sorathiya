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
    /// Controller for managing Marvel characters (Version 1).
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "GET")]
    [RoutePrefix("api/V1/MarvelCharacter")]
    [BasicAuthenticationAttribute]
    public class MarvelCharacterV1Controller : ApiController
    {
        // Static list to store Marvel characters
        static List<MarvelCharacterV1> marvelCharacterList = new List<MarvelCharacterV1>
            {
                new MarvelCharacterV1 {Name = "Tony Stark", SuperheroName = "Iron Man", Role = "Superhero" },
                new MarvelCharacterV1 {Name = "Steve Rogers", SuperheroName = "Captain America", Role = "Superhero" },
                new MarvelCharacterV1 {Name = "Bruce Banner", SuperheroName = "Hulk", Role = "Superhero"},
                new MarvelCharacterV1 {Name = "Thor Odinson", SuperheroName = "Thor", Role = "Superhero"},
                new MarvelCharacterV1 {Name = "Natasha Romanoff", SuperheroName = "Black Widow", Role = "Superhero"},
                new MarvelCharacterV1 {Name = "Clint Barton", SuperheroName = "Hawkeye", Role = "Superhero"},
                new MarvelCharacterV1 {Name = "Loki Laufeyson", SuperheroName = "Loki", Role = "Villain"},
                new MarvelCharacterV1 {Name = "Thanos", SuperheroName = "Thanos", Role = "Villain"},
                new MarvelCharacterV1 {Name = "Peter Parker", SuperheroName = "Spider-Man", Role = "Superhero"},
                new MarvelCharacterV1 {Name = "Scott Lang", SuperheroName = "Ant-Man", Role = "Superhero"}

            };
        // Cache manager for caching responses
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
            List<MarvelCharacterV1> superHeros = marvelCharacterList.FindAll(chr => chr.Role.Equals("Superhero"));
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
            List<MarvelCharacterV1> Villains = marvelCharacterList.FindAll(chr => chr.Role.Equals("Villain"));
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
        public IHttpActionResult AddNewCharacter(MarvelCharacterV1 character)
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
        public IHttpActionResult UpdateCharacterInfo(int id, MarvelCharacterV1 character)
        {
            var targetCharacter = marvelCharacterList.Find(chr => chr.CharacterId == id);
            if (targetCharacter == null)
            {
                return NotFound();
            }
            targetCharacter.Name = character.Name;
            targetCharacter.SuperheroName = character.SuperheroName;
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
