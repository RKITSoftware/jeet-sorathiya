using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Caching;
using Test_of_web_development_training.BL.Interface;
using Test_of_web_development_training.Extension;
using Test_of_web_development_training.Models;
using Test_of_web_development_training.Models.DTO;
using Test_of_web_development_training.Models.Enum;
using Test_of_web_development_training.Models.POCO;
using static Test_of_web_development_training.BL.Common.BLCache;

namespace Test_of_web_development_training.BL
{
    /// <summary>
    /// Manages Marvel characters CRUD operations.
    /// </summary>
    public class BLMarvelCharacterManagerV1 : IDataHandlerService<DTOMarvelCharacterV1>
    {
        #region  Private Fields
        private MarvelCharacterV1 _objMarvelCharacter;
        private int _characterId;
        private static readonly List<MarvelCharacterV1> _marvelCharacterList = new List<MarvelCharacterV1>
        {
            new MarvelCharacterV1 {CharacterId = 1, Name = "Tony Stark", SuperheroName = "Iron Man", Role = "Superhero" },
            new MarvelCharacterV1 {CharacterId = 2, Name = "Steve Rogers", SuperheroName = "Captain America", Role = "Superhero" },
            new MarvelCharacterV1 {CharacterId = 3, Name = "Bruce Banner", SuperheroName = "Hulk", Role = "Superhero"},
            new MarvelCharacterV1 {CharacterId = 4, Name = "Thor Odinson", SuperheroName = "Thor", Role = "Superhero"},
            new MarvelCharacterV1 {CharacterId = 5, Name = "Natasha Romanoff", SuperheroName = "Black Widow", Role = "Superhero"},
            new MarvelCharacterV1 {CharacterId = 6, Name = "Clint Barton", SuperheroName = "Hawkeye", Role = "Superhero"},
            new MarvelCharacterV1 {CharacterId = 7, Name = "Loki Laufeyson", SuperheroName = "Loki", Role = "Villain"},
            new MarvelCharacterV1 {CharacterId = 8, Name = "Thanos", SuperheroName = "Thanos", Role = "Villain"},
            new MarvelCharacterV1 {CharacterId = 9, Name = "Peter Parker", SuperheroName = "Spider-Man", Role = "Superhero"},
            new MarvelCharacterV1 {CharacterId = 10, Name = "Scott Lang", SuperheroName = "Ant-Man", Role = "Superhero"}
        }; 
        #endregion

        public Response objResponse;
        public EnmType EntryType { get; set; }

        #region Constructor
        /// <summary>
        /// constructor 
        /// </summary>
        public BLMarvelCharacterManagerV1()
        {
            _objMarvelCharacter = new MarvelCharacterV1();
            objResponse = new Response();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all Marvel characters.
        /// </summary>
        /// <returns>List of all Marvel characters.</returns>
        public Response GetAllCharacters()
        {
            objResponse.Data = ServerCache.Get("_marvelCharacterV1List");
            if (objResponse.Data != null)
            {
                return objResponse;
            }

            // If the list is not in the cache, add it to the cache with a 100-second expiration time
            TimeSpan ts = new TimeSpan(0, 0, 100);
            // add userlist into cache
            ServerCache.Add("_marvelCharacterV1List", _marvelCharacterList, null, DateTime.MaxValue, ts, CacheItemPriority.Default, null);
            objResponse.Data = _marvelCharacterList;
            return objResponse;
        }

        /// <summary>
        /// Retrieves a Marvel character by ID.
        /// </summary>
        /// <param name="id">ID of the character </param>
        /// <returns>The Marvel character with the specified ID.</returns>
        public MarvelCharacterV1 GetCharacterById(int id)
        {
            return _marvelCharacterList.FirstOrDefault(chr => chr.CharacterId == id);
        }

        /// <summary>
        /// Retrieves all Marvel superheroes.
        /// </summary>
        /// <returns>List of all Marvel superheroes.</returns>
        public List<MarvelCharacterV1> GetSuperheroes()
        {
            return _marvelCharacterList.Where(chr => chr.Role.Equals("Superhero")).ToList();
        }

        /// <summary>
        /// Retrieves all Marvel villains.
        /// </summary>
        /// <returns>List of all Marvel villains.</returns>
        public List<MarvelCharacterV1> GetVillains()
        {
            return _marvelCharacterList.Where(chr => chr.Role.Equals("Villain")).ToList();
        }

        /// <summary>
        /// Deletes a Marvel character by ID.
        /// </summary>
        /// <param name="id">ID of the character </param>
        /// <returns>True if the character was successfully deleted, otherwise false.</returns>
        public bool DeleteCharacter(int id)
        {
            //MarvelCharacterV1 targetCharacter = _marvelCharacterList.FirstOrDefault(chr => chr.CharacterId == id);
            //if (targetCharacter != null)
            //{
            //    _marvelCharacterList.Remove(targetCharacter);
            //    return true;
            //}
            //return false;
            int removeCount = _marvelCharacterList.RemoveAll(chr => chr.CharacterId == id);
            if (removeCount > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Performs pre-save operations on the Marvel character object.
        /// </summary>
        /// <param name="id">ID of the character (if any).</param>
        /// <param name="objDto">DTO representation of the Marvel character.</param>
        public void PreSave(DTOMarvelCharacterV1 objDto, int id = 0)
        {
            _objMarvelCharacter = objDto.Convert<MarvelCharacterV1>();
            if (EntryType == EnmType.A)
            {
                // Generate a new GUID
                Guid newGuid = Guid.NewGuid();
                int newId = Math.Abs(newGuid.GetHashCode());
                _objMarvelCharacter.CharacterId = newId;
            }
            else if (EntryType == EnmType.E)
            {
                if (id > 0)
                {
                    _characterId = id;
                }
            }
        }

        /// <summary>
        /// Validates the Marvel character object before saving.
        /// </summary>
        /// <returns>Response indicating the result of validation.</returns>
        public Response Validation()
        {
            if (EntryType == EnmType.E)
            {
                if (!(_characterId > 0))
                {
                    objResponse.IsError = true;
                    objResponse.Message = "Enter Correct Id";
                }
                else
                {
                    MarvelCharacterV1 targetCharacter = _marvelCharacterList.FirstOrDefault(chr => chr.CharacterId == _characterId);
                    if (targetCharacter != null)
                    {
                        objResponse.Data = targetCharacter;
                    }
                    else
                    {
                        objResponse.IsError = true;
                        objResponse.Message = "Character Not Found";
                    }
                }
            }
            return objResponse;

        }

        /// <summary>
        /// Saves the Marvel character object.
        /// </summary>
        /// <returns>Response indicating the result of the save operation.</returns>
        public Response Save()
        {
            if (EntryType == EnmType.A)
            {
                _marvelCharacterList.Add(_objMarvelCharacter);
                objResponse.Data = _objMarvelCharacter;
                objResponse.Message = "New Character is Added";
            }
            else if (EntryType == EnmType.E)
            {

                objResponse.Data.Name = _objMarvelCharacter.Name;
                objResponse.Data.SuperheroName = _objMarvelCharacter.SuperheroName;
                objResponse.Data.Role = _objMarvelCharacter.Role;
                objResponse.Message = "Character Is Updated";
            }
            return objResponse;
        } 
        #endregion
    }
}
