using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Test_of_web_development_training.BL;
using Test_of_web_development_training.Models;
using Test_of_web_development_training.Models.DTO;
using Test_of_web_development_training.Models.Enum;
using Test_of_web_development_training.SEC__Security;

namespace Test_of_web_development_training.Controllers
{
    /// <summary>
    /// Controller for managing Marvel characters (Version 1).
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "GET")]
    [RoutePrefix("api/V1/MarvelCharacter")]
    [BasicAuthentication]
    public class CLMarvelCharacterV1Controller : ApiController
    {
        private readonly BLMarvelCharacterManagerV1 _blMarvelCharacterManagerV1;
        private Response _objResponse;

        /// <summary>
        /// Default constructor to initialize necessary instances.
        /// </summary>
        public CLMarvelCharacterV1Controller()
        {

            _blMarvelCharacterManagerV1 = new BLMarvelCharacterManagerV1();
        }
        #region Get Methods

        /// <summary>
        /// Retrieves a list of all Marvel characters.
        /// </summary>
        /// <returns>the list of Marvel characters.</returns>
        [HttpGet]
        [Route("ListOfCharacters")]
        [BasicAuthorization(Roles = "Admin,Subscriber,NonSubscriber")]
        public Response ListOfCharacters()
        {          
            return _blMarvelCharacterManagerV1.GetAllCharacters();
        }


        /// <summary>
        /// Retrieves information about a specific Marvel character.
        /// </summary>
        /// <param name="id">The ID of the character.</param>
        /// <returns>the Marvel character information.</returns>
        [HttpGet]
        [Route("CharacterInfo/{id}")]
        [BasicAuthorizationAttribute(Roles = "Admin,Subscriber")]
        public IHttpActionResult CharacterInfo(int id) // bl??
        {
            var character = _blMarvelCharacterManagerV1.GetCharacterById(id);
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);

        }

        /// <summary>
        /// Retrieves a list of all Marvel superheroes.
        /// </summary>
        /// <returns>the list of Marvel superheroes.</returns>
        [HttpGet]
        [Route("ListOfSuperHeros")]
        [BasicAuthorizationAttribute(Roles = "Admin,Subscriber")]
        public IHttpActionResult ListOfSuperHeros() // bl??
        {
            var superHeros = _blMarvelCharacterManagerV1.GetSuperheroes();
            if (superHeros.Count == 0)
            {
                return NotFound();
            }
            return Ok(superHeros);
        }

        /// <summary>
        /// Retrieves a list of all Marvel villains.
        /// </summary>
        /// <returns>the list of Marvel villains.</returns>
        [HttpGet]
        [Route("ListOfVillain")]
        [BasicAuthorizationAttribute(Roles = "Admin,Subscriber")]
        public IHttpActionResult ListOfVillain()
        {
            var villains = _blMarvelCharacterManagerV1.GetVillains();
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
        /// <returns>A response indicating the result of adding the character.</returns>
        [HttpPost]
        [Route("AddNewCharacter")]
        [BasicAuthorization(Roles = "Admin")]
        public Response AddNewCharacter(DTOMarvelCharacterV1 character)
        {
            _blMarvelCharacterManagerV1.Type = EnmType.A;
            _blMarvelCharacterManagerV1.PreSave(null, character);
            _objResponse = _blMarvelCharacterManagerV1.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _blMarvelCharacterManagerV1.Save();
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
        /// <returns>A response indicating the result of updating the character.</returns>
        [HttpPut]
        [Route("UpdateCharacterInfo/{id}")]
        [BasicAuthorization(Roles = "Admin")]
        public Response UpdateCharacterInfo(int id, DTOMarvelCharacterV1 character)
        {
            _blMarvelCharacterManagerV1.Type = EnmType.E;
            _blMarvelCharacterManagerV1.PreSave(id, character);
            _objResponse = _blMarvelCharacterManagerV1.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _blMarvelCharacterManagerV1.Save();
            }
            return _objResponse;
        }
        #endregion

        #region Delete Method


        /// <summary>
        /// Deletes a Marvel character.
        /// </summary>
        /// <param name="id">The ID of the character to be deleted.</param>
        /// <returns>An HTTP response message indicating the result of deleting the character.</returns>
        [HttpDelete]
        [Route("DeleteCharacter/{id}")]
        [BasicAuthorization(Roles = "Admin")]
        public IHttpActionResult DeleteCharacter(int id)
        {
            var deleted = _blMarvelCharacterManagerV1.DeleteCharacter(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }
        #endregion
    }
}
