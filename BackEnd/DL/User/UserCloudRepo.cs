using System;
using System.Collections.Generic;
using System.Linq;
using Entity = DL.Entities;
using Model = Models;

namespace DL
{
    public class UserCloudRepo : IUserRepo
    {
        private Entity.P3ApiContext _context;

        public UserCloudRepo(Entity.P3ApiContext p_context)
        {
            _context = p_context;
        }
        public Model.User AddUser(Model.User p_Users)
        {
            _context.Users.Add
            (
                new Entity.User()
                {
                    UserName = p_Users.UserName,
                    UserPass = p_Users.UserPass,
                    Email = p_Users.Email,
                    NameOfUser = p_Users.NameOfUser
                }
            );
            _context.SaveChanges();
            return p_Users;
        }

        public Model.User AddUserFromAuth0(string p_email)
        {
            List<Model.User> ListOfUsers = GetAllUsers();
            var rand = new Random();
            List<int> randNum = new List<int>();
            bool run = true;
            int count=0;
            while (run)
            {
                for (int i = 0; i <= 3; i++)
                    randNum.Add(rand.Next(101));
                foreach (Model.User item in ListOfUsers)
                {
                    if($"user{randNum.ToString()}" == item.UserName)
                    {count++; }
                    //if the userName that will be made is unique stop the loop
                    if(count == 0)
                    {run = false; }
                } 
            } 
            _context.Users.Add
            (
                new Entity.User()
                {
                    UserName = "user"+randNum.ToString(),
                    UserPass = "Password123!",
                    Email = p_email,
                    NameOfUser = "newUser"
                }
            );
            _context.SaveChanges();
            return new Model.User()
            {
                UserName = "user" + randNum.ToString(),
                UserPass = "Password123!",
                Email = p_email,
                NameOfUser = "newUser"
            };
        }

        public List<Model.User> GetAllUsers()
        {
            return _context.Users.Select(user =>
                new Model.User()
                {
                    ID = user.Id,
                    UserName = user.UserName,
                    UserPass = user.UserPass,
                    Email = user.Email,
                    NameOfUser = user.NameOfUser
                }
            ).ToList();

        }


        public Model.User DeleteUser(int p_user_Id)
        {
            var result = _context.Users
                .FirstOrDefault<Entity.User>(user =>
                    user.Id == p_user_Id);
            _context.Users.Remove(result);
            _context.SaveChanges();

            return new Model.User()
            {
                ID = result.Id,
                UserName = result.UserName,
                UserPass = result.UserPass,
                Email = result.Email,
                NameOfUser = result.NameOfUser
            };
  
        }

    }
}
