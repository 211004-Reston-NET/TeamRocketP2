using System.Collections.Generic;
using Models;
namespace DL
{
    public interface IUserRepo
    {
        /// <summary>
        /// will return a list of Users
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUsers();

        /// <summary>
        /// Adds passed user to the database
        /// </summary>
        /// <param name="_Users"></param>
        /// <returns>added user</returns>
        User AddUser(User _Users);

        /// <summary>
        /// add user if not in Db when loged in with auth0
        /// </summary>
        /// <param name="_email"></param>
        /// <returns></returns>
        User AddUserFromAuth0(string _email);

        /// <summary>
        /// modify the current user info with the passed info (exept email)
        /// </summary>
        /// <param name="_User"></param>
        /// <returns></returns>
        User UpdateUser(User _User);

        /// <summary>
        /// removes the passed user from the DB
        /// </summary>
        /// <param name="p_user"></param>
        /// <returns></returns>
        User DeleteUser(int _user_Id);
    }
}