using System;
using System.Collections.Generic;
using System.Linq;
using Test_of_web_development_training.BL.Interface;
using Test_of_web_development_training.Extension;
using Test_of_web_development_training.Models;
using Test_of_web_development_training.Models.DTO;
using Test_of_web_development_training.Models.Enum;
using Test_of_web_development_training.Models.POCO;

namespace Test_of_web_development_training.BL
{
    /// <summary>
    /// Manages user data CRUD operations.
    /// </summary>
    public class BLUserManager : IDataHandlerService<DTOUser>
    {
        private User _objUser;
        private int _id;
        // A static list to store user data
        private static readonly List<User> _userList = new List<User>
        {
            new User{ Id=1, UserName="Jeet", Password="1234", Role="Admin"},
            new User{ Id=2, UserName="U1", Password = "1234", Role="Subscriber"},
            new User{ Id=3, UserName="U2", Password = "1234", Role = "NonSubscriber"}
        };
        public Response objResponse;
        public EnmType Type { get; set; }

        /// <summary>
        /// constructor.
        /// </summary>
        public BLUserManager()
        {
            _objUser = new User();
            objResponse = new Response();
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>List of all users.</returns>
        public List<User> GetAllUsers()
        {
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
            User currentUser = _userList.Find(usr => usr.Id == id);
            _userList.Remove(currentUser);
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
            if (_userList.Any(usr => usr.UserName == userName && usr.Password == password))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Performs pre-save operations on the user object.
        /// </summary>
        /// <param name="id">ID of the user (if any).</param>
        /// <param name="objDto">DTO representation of the user.</param>
        public void PreSave(int? id, DTOUser objDto)
        {
            _objUser = objDto.Convert<User>();
            if (Type == EnmType.A)
            {
                // Generate a new GUID
                Guid newGuid = Guid.NewGuid();
                _objUser.Id = Math.Abs(newGuid.GetHashCode());
            }
            if (Type == EnmType.E)
            {
                if (id > 0)
                {
                    _id = (int)id;
                }
            }
        }

        /// <summary>
        /// Validates the user object before saving.
        /// </summary>
        /// <returns>Response indicating the result of validation.</returns>
        public Response Validation()
        {
            if (Type == EnmType.E)
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
            if (Type == EnmType.A)
            {
                _userList.Add(_objUser);
                objResponse.Data = _userList;
                return objResponse;
            }
            if (Type == EnmType.E)
            {
                objResponse.Data.UserName = _objUser.UserName;
                objResponse.Data.Password = _objUser.Password;
                objResponse.Data.Role = _objUser.Role;
            }
            return objResponse;
        }
    }
}