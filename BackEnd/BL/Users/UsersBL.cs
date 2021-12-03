using System;
using System.Collections.Generic;
using System.Linq;
using DL;
using Models;

namespace BL
{
    public class UsersBL : IUserBL
    {
        IUserRepo _repo;

        public UsersBL(IUserRepo p_repo)
        {
            _repo = p_repo;
        }
        public User AddUser(User p_user)
        {
            return _repo.AddUser(p_user);
        }

        public User AddUserFromAuth0(string p_email)
        {
            return _repo.AddUserFromAuth0(p_email);
        }

        public List<User> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }

        //another column will be added to the DB that is name this will be the users actual name
        //and the current UserName will be changed into a unique username use for login and displayed on posts/replies
        //this will search by the new unique username once the DB is updated meaning it will return a user obj insted of a list of obj
        public List<User> GetUserByName(string p_name)
        {
            List<User> listOfUsers = _repo.GetAllUsers();

            //Select method will give a list of boolean if the condition was true/false
            //Where method will give the actual element itself based on some condition
            //ToList method will convert into List that our method currently needs to return.
            return listOfUsers.Where(usr => usr.UserName.ToLower().Contains(p_name.ToLower())).ToList();
        }

        public User GetUserById(int p_Id)
        {
            List<User> listOfUsers = _repo.GetAllUsers();


            List<User> Found = (listOfUsers.Where(usr => usr.ID.Equals(p_Id))).ToList();

            return Found[0];
        }

        public User DeleteUser(int p_user_Id)
        {
            return _repo.DeleteUser(p_user_Id);
        }

        public User GetUserByEmail(string p_email)
        {
            try{
            List<User> listOfUsers = _repo.GetAllUsers();
            List<User> Found = (listOfUsers.Where(usr => usr.Email.Equals(p_email))).ToList();
            return Found[0];
            }
            catch(Exception)
            {return new User();}
        }
    }
}
