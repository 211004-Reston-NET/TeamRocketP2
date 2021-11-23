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
    }
}