using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Test_of_web_development_training.BL;
using Test_of_web_development_training.DAL;
using Test_of_web_development_training.Models.DTO;
using Test_of_web_development_training.Models.Enum;
using Test_of_web_development_training.SEC__Security;
using Response = Test_of_web_development_training.Models.Response;

namespace Test_of_web_development_training.Controllers
{
    /// <summary>
    /// Controller for managing Marvel characters (Version 2).
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "GET")]
    [RoutePrefix("api/V2/MarvelCharacter")]
    [BasicAuthentication]
    public class CLMarvelCharacterV2Controller : ApiController
    {
        // Cache manager instance for caching responses
        private readonly BLMarvelCharacterManagerV2 _bLMarvelCharacterManagerV2;
        private readonly CacheManager _cacheManager;
        private Response _objResponse;

        /// <summary>
        /// Default constructor to initialize necessary instances.
        /// </summary>
        public CLMarvelCharacterV2Controller()
        {
            _bLMarvelCharacterManagerV2 = new BLMarvelCharacterManagerV2();
            _cacheManager = new CacheManager();
        }


        #region Get Methods

        /// <summary>
        /// Retrieves a list of all Marvel characters.
        /// </summary>
        /// <returns>list of Marvel characters.</returns>
        [HttpGet]
        [Route("ListOfCharacters")]
        [BasicAuthorization(Roles = "Admin,Subscriber,NonSubscriber")]
        public HttpResponseMessage ListOfCharacters()
        {
            return _cacheManager.GetCachedResponse(Request, _bLMarvelCharacterManagerV2.GetAllCharacters);
        }


        /// <summary>
        /// Retrieves information about a specific Marvel character.
        /// </summary>
        /// <param name="id">The ID of the character.</param>
        /// <returns>the Marvel character information.</returns>
        [HttpGet]
        [Route("CharacterInfo/{id}")]
        [BasicAuthorizationAttribute(Roles = "Admin,Subscriber")]
        public IHttpActionResult CharacterInfo(int id)
        {
            var character = _bLMarvelCharacterManagerV2.GetCharacterById(id);
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }


        /// <summary>
        /// Retrieves a list of all Marvel superheroes.
        /// </summary>
        /// <returns>list of Marvel superheroes.</returns>
        [HttpGet]
        [Route("ListOfSuperHeros")]
        [BasicAuthorizationAttribute(Roles = "Admin,Subscriber")]
        public IHttpActionResult ListOfSuperHeros()
        {
            var superHeros = _bLMarvelCharacterManagerV2.GetSuperheroes();
            if (superHeros.Count == 0)
            {
                return NotFound();
            }
            return Ok(superHeros);
        }


        /// <summary>
        /// Retrieves a list of all Marvel villains.
        /// </summary>
        /// <returns>list of Marvel villains.</returns>
        [HttpGet]
        [Route("ListOfVillain")]
        [BasicAuthorizationAttribute(Roles = "Admin,Subscriber")]
        public IHttpActionResult ListOfVillain()
        {
            var villains = _bLMarvelCharacterManagerV2.GetVillains();
            if (villains.Count == 0)
            {
                return NotFound();
            }
            return Ok(villains);
        }
        #endregion

        #region Post Method


        /// <summary>
        /// Adds a new Marvel character.
        /// </summary>
        /// <param name="character">The Marvel character to be added.</param>
        /// <returns>the result of adding the character.</returns>
        [HttpPost]
        [Route("AddNewCharacter")]
        [BasicAuthorization(Roles = "Admin")]
        public Response AddNewCharacter(DTOMarvelCharacterV2 character)
        {
            _bLMarvelCharacterManagerV2.Type = EnmType.A;
            _bLMarvelCharacterManagerV2.PreSave(null, character);
            _objResponse = _bLMarvelCharacterManagerV2.Validation();
            if (!_objResponse.IsError)
            {
                _bLMarvelCharacterManagerV2.Save();
            }
            return _objResponse;
        }
        #endregion

        #region Put Method

        /// <summary>
        /// Updates information of a Marvel character.
        /// </summary>
        /// <param name="id">The ID of the character to be updated.</param>
        /// <param name="character">The updated information of the Marvel character.</param>
        /// <returns>the result of updating the character.</returns>
        [HttpPut]
        [Route("UpdateCharacterInfo/{id}")]
        [BasicAuthorization(Roles = "Admin")]
        public Response UpdateCharacterInfo(int id, DTOMarvelCharacterV2 character)
        {
            _bLMarvelCharacterManagerV2.Type = EnmType.E;
            _bLMarvelCharacterManagerV2.PreSave(id, character);
            _objResponse = _bLMarvelCharacterManagerV2.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _bLMarvelCharacterManagerV2.Save();
            }
            return _objResponse;
        }
        #endregion

        #region Delete Method


        /// <summary>
        /// Deletes a Marvel character.
        /// </summary>
        /// <param name="id">The ID of the character to be deleted.</param>
        /// <returns>the result of deleting the character.</returns>
        [HttpDelete]
        [Route("DeleteCharacter/{id}")]
        [BasicAuthorization(Roles = "Admin")]
        public IHttpActionResult DeleteCharacter(int id)
        {
            var deleted = _bLMarvelCharacterManagerV2.DeleteCharacter(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }
        #endregion
    }
}
