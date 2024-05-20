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
    /// Manages Marvel characters version 2 CRUD operations.
    /// </summary>
    public class BLMarvelCharacterManagerV2 : IDataHandlerService<DTOMarvelCharacterV2>
    {
        #region  Private Fields
        private MarvelCharacterV2 _objMarvelCharacterV2;
        private int _characterId;
        private static readonly List<MarvelCharacterV2> _marvelCharacterList = new List<MarvelCharacterV2>
        {
            new MarvelCharacterV2 {CharacterId = 1, FullName = "Tony Stark", HeroName = "Iron Man", Abilities = new string[] { "Powered Armor", "Genius-level intellect" }, Birthplace = "Earth", Team = "Avengers", Role = "Superhero" },
            new MarvelCharacterV2 {CharacterId = 2, FullName = "Steve Rogers", HeroName = "Captain America", Abilities = new string[] { "Superhuman strength", "Enhanced agility" }, Birthplace = "Earth", Team = "Avengers", Role = "Superhero" },
            new MarvelCharacterV2 {CharacterId = 3, FullName = "Bruce Banner", HeroName = "Hulk", Abilities = new string[] { "Superhuman strength", "Regenerative healing factor" }, Birthplace = "Earth", Team = "Avengers", Role = "Superhero" },
            new MarvelCharacterV2 {CharacterId = 4, FullName = "Thor Odinson", HeroName = "Thor", Abilities = new string[] { "God-like strength", "Control over lightning" }, Birthplace = "Asgard", Team = "Avengers", Role = "Superhero" },
            new MarvelCharacterV2 {CharacterId = 5, FullName = "Natasha Romanoff", HeroName = "Black Widow", Abilities = new string[] { "Master martial artist", "Espionage expert" }, Birthplace = "Earth", Team = "Avengers", Role = "Superhero" },
            new MarvelCharacterV2 {CharacterId = 6, FullName = "Clint Barton", HeroName = "Hawkeye", Abilities = new string[] { "Master archer", "Exceptional hand-to-hand combatant" }, Birthplace = "Earth", Team = "Avengers", Role = "Superhero" },
            new MarvelCharacterV2 {CharacterId = 7, FullName = "Loki Laufeyson", HeroName = "Loki", Abilities = new string[] { "Illusions", "Shape-shifting" }, Birthplace = "Asgard", Team = "Villains", Role = "Villain" },
            new MarvelCharacterV2 {CharacterId = 8, FullName = "Thanos", HeroName = "Thanos", Abilities = new string[] { "Superhuman strength", "Genius-level intellect" }, Birthplace = "Titan", Team = "Villains", Role = "Villain" },
            new MarvelCharacterV2 {CharacterId = 9, FullName = "Peter Parker", HeroName = "Spider-Man", Abilities = new string[] { "Wall-crawling", "Spider-sense" }, Birthplace = "Earth", Team = "Avengers", Role = "Superhero" },
            new MarvelCharacterV2 {CharacterId = 10, FullName = "Scott Lang", HeroName = "Ant-Man", Abilities = new string[] { "Size manipulation", "Control of ants" }, Birthplace = "Earth", Team = "Avengers", Role = "Superhero" }
        }; 
        #endregion

        public Response objResponse;
        public EnmType EntryType { get; set; }

        #region Constructor
        /// <summary>
        /// constructor.
        /// </summary>
        public BLMarvelCharacterManagerV2()
        {
            _objMarvelCharacterV2 = new MarvelCharacterV2();
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
            objResponse.Data = ServerCache.Get("_marvelCharacterV2List");
            if (objResponse.Data != null)
            {
                return objResponse;
            }

            // If the list is not in the cache, add it to the cache with a 100-second expiration time
            TimeSpan ts = new TimeSpan(0, 0, 100);
            // add userlist into cache
            ServerCache.Add("_marvelCharacterV2List", _marvelCharacterList, null, DateTime.MaxValue, ts, CacheItemPriority.Default, null);
            objResponse.Data = _marvelCharacterList;
            return objResponse;
        }

        /// <summary>
        /// Retrieves a Marvel character by ID.
        /// </summary>
        /// <param name="id">ID of the character </param>
        /// <returns>The Marvel character with the specified ID.</returns>
        public MarvelCharacterV2 GetCharacterById(int id)
        {
            return _marvelCharacterList.FirstOrDefault(chr => chr.CharacterId == id);
        }

        /// <summary>
        /// Retrieves all Marvel superheroes.
        /// </summary>
        /// <returns>List of all Marvel superheroes.</returns>
        public List<MarvelCharacterV2> GetSuperheroes()
        {
            return _marvelCharacterList.Where(chr => chr.Role.Equals("Superhero")).ToList();
        }

        /// <summary>
        /// Retrieves all Marvel villains.
        /// </summary>
        /// <returns>List of all Marvel villains.</returns>
        public List<MarvelCharacterV2> GetVillains()
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
            //var targetCharacter = marvelCharacterList.FirstOrDefault(chr => chr.CharacterId == id);
            //if (targetCharacter != null)
            //{
            //    marvelCharacterList.Remove(targetCharacter);
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
        public void PreSave(DTOMarvelCharacterV2 objDto, int id = 0)
        {
            _objMarvelCharacterV2 = objDto.Convert<MarvelCharacterV2>();
            if (EntryType == EnmType.A)
            {
                // Generate a new GUID
                Guid newGuid = Guid.NewGuid();
                int newId = Math.Abs(newGuid.GetHashCode());
                _objMarvelCharacterV2.CharacterId = newId;
            }
            if (EntryType == EnmType.E)
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
                    MarvelCharacterV2 targetCharacter = _marvelCharacterList.FirstOrDefault(chr => chr.CharacterId == _characterId);
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
                _marvelCharacterList.Add(_objMarvelCharacterV2);
                objResponse.Data = _objMarvelCharacterV2;
                objResponse.Message = "New Character is Added";
            }
            else if (EntryType == EnmType.E)
            {
                objResponse.Data.FullName = _objMarvelCharacterV2.FullName;
                objResponse.Data.HeroName = _objMarvelCharacterV2.HeroName;
                objResponse.Data.Abilities = _objMarvelCharacterV2.Abilities;
                objResponse.Data.Birthplace = _objMarvelCharacterV2.Birthplace;
                objResponse.Data.Team = _objMarvelCharacterV2.Team;
                objResponse.Data.Role = _objMarvelCharacterV2.Role;

                objResponse.Message = "Character Is Updated";
            }
            return objResponse;
        } 
        #endregion
    }
}