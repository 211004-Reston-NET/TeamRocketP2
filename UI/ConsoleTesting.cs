using System.Collections.Generic;
using BL;
using Models;

namespace UI
{
    public class ConsoleTesting
    {
        IUserBL _userBL;

        public ConsoleTesting(IUserBL p_userBL)
        {
            _userBL=p_userBL;
        }

        public  User TestAdd()
        {
            return _userBL.AddUser( new User()
            {
                UserName = "name",
                UserPass = "password",
                Email = "mail@mail.com"
            });
        }

        public List<User> TestShowAll()
        {
            return _userBL.GetAllUsers();
        }
    }
}