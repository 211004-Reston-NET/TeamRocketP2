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
                    Email = p_Users.Email
                }
            );
            _context.SaveChanges();
            return p_Users;
        }

        public List<Model.User> GetAllUsers()
        {
            return _context.Users.Select(user =>
                new Model.User()
                {
                    ID = user.Id,
                    UserName = user.UserName,
                    UserPass = user.UserPass,
                    Email = user.Email
                }
            ).ToList();

        }


        public Model.User DeleteUser(Model.User p_user)
        {
            
            _context.Users.Remove(
                new Entity.User()
                {
                    Id=p_user.ID,
                    UserName = p_user.UserName,
                    UserPass = p_user.UserPass,
                    Email = p_user.Email
                }
            );
            _context.SaveChanges();
            return p_user;
        }
        
    }
}
