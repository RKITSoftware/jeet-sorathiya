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
    /// Manages user data CRUD operations.
    /// </summary>
    public class BLUserManager : IDataHandlerService<DTOUser>
    {

        #region Private Fields
        private User _objUser;
        private int _id;
        // A static list to store user data
        private static readonly List<User> _userList = new List<User>
        {
            new User{ Id=1, UserName="Jeet", Password="1234", Role="Admin"},
            new User{ Id=2, UserName="U1", Password = "1234", Role="Subscriber"},
            new User{ Id=3, UserName="U2", Password = "1234", Role = "NonSubscriber"}
        }; 
        #endregion
        public EnmType EntryType { get; set; }

        public Response objResponse;

        #region Constructor
        /// <summary>
        /// constructor.
        /// </summary>
        public BLUserManager()
        {
            _objUser = new User();
            objResponse = new Response();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>List of all users.</returns>
        public List<User> GetAllUsers()
        {
            List<User> userList = ServerCache.Get("_userList") as List<User>;
            if (userList != null)
            {
                return userList;
            }
            // If the list is not in the cache, add it to the cache with a 100-second expiration time
            TimeSpan ts = new TimeSpan(0, 0, 100);
            // add userlist into cache
            ServerCache.Add("_userList", _userList, null, DateTime.MaxValue, ts, CacheItemPriority.Default, null);
            return _userList;
        }

        /// <summary>
        /// Retrieves a user by ID.
        /// </summary>
        /// <param name="id">ID of the user.</param>
        /// <returns>The user with the specified ID.</returns>
        public User GetUserById(int id)
        {
            return _userList.FirstOrDefault(usr => usr.Id == id);
        }

        /// <summary>
        /// Deletes a user based ID.
        /// </summary>
        /// <param name="id">The ID of the user to be deleted.</param>
        public void Delete(int id)
        {
            //User currentUser = _userList.Find(usr => usr.Id == id);
            //_userList.Remove(currentUser);
            _userList.RemoveAll(usr => usr.Id == id);
        }

        /// <summary>
        /// Retrieves user details based on the username.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <returns>The user details if found; otherwise, null.</returns>
        public User UserDetails(string userName)
        {
            return _userList.Find(usr => usr.UserName == userName);
        }

        /// <summary>
        /// Checks if a user with the provided username and password exists.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>True if the user exists with the provided credentials; otherwise, false.</returns>
        public bool IsUser(string userName, string password)
        {
            return _userList.Any(usr => usr.UserName.Equals(userName) && usr.Password.Equals(password));

        }

        /// <summary>
        /// Performs pre-save operations on the user object.
        /// </summary>
        /// <param name="id">ID of the user (if any).</param>
        /// <param name="objDto">DTO representation of the user.</param>
        public void PreSave(DTOUser objDto, int id = 0)
        {
            _objUser = objDto.Convert<User>();
            if (EntryType == EnmType.A)
            {
                // Generate a new GUID
                Guid newGuid = Guid.NewGuid();
                _objUser.Id = Math.Abs(newGuid.GetHashCode());
            }
            if (EntryType == EnmType.E)
            {
                if (id > 0)
                {
                    _id = id;
                }
            }
        }

        /// <summary>
        /// Validates the user object before saving.
        /// </summary>
        /// <returns>Response indicating the result of validation.</returns>
        public Response Validation()
        {
            if (EntryType == EnmType.E)
            {
                if (!(_id > 0))
                {
                    objResponse.IsError = true;
                    objResponse.Message = "Enter Correct Id";
                }
                else
                {
                    User currentUser = _userList.Find(usr => usr.Id == _id);
                    if (currentUser != null)
                    {
                        objResponse.Data = currentUser;
                    }
                    else
                    {
                        objResponse.IsError = true;
                        objResponse.Message = "User Not Found";
                    }
                }
            }
            return objResponse;
        }

        /// <summary>
        /// Saves the user object.
        /// </summary>
        /// <returns>Response indicating the result of the save operation.</returns>
        public Response Save()
        {
            if (EntryType == EnmType.A)
            {
                _userList.Add(_objUser);
                objResponse.Data = _userList;
            }
            else if (EntryType == EnmType.E)
            {
                objResponse.Data.UserName = _objUser.UserName;
                objResponse.Data.Password = _objUser.Password;
                objResponse.Data.Role = _objUser.Role;
            }
            return objResponse;
        } 
        #endregion
    }
}