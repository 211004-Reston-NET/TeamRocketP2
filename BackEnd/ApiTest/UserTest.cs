using System;
using Xunit;
using Model = Models;
using Entity = DL.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DL;
using BL;

namespace ApiTest
{
    public class UserTest
    {

        private readonly DbContextOptions<DL.Entities.P3ApiContext> _options;

        public UserTest()
        {
            _options = new DbContextOptionsBuilder<DL.Entities.P3ApiContext>()
                        .UseSqlite("Filename =UserTest.db").Options;
                    
            Seed();
        }
        [Fact]
        public void ShouldGetAllUsers()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IUserRepo repo = new UserCloudRepo(context);

                //Act -- a call to the method that is being tested 
                List<Model.User> test = repo.GetAllUsers();

                //Assert -- expected outcome of Act
                //Equal(number of customers expected, #of customers retrevied from GetAllCustomers)
                Assert.Equal(2, test.Count);
                Assert.Equal("Traveler", test[1].UserName);
            }

        }

        [Fact]
        public void GetUserByIdTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IUserBL BL = new UsersBL(new UserCloudRepo(context));
                Entity.User test = context.Users.Find(1);
                //Act -- a call to the method that is being tested 
                Model.User found = BL.GetUserById(test.Id);

                //Assert -- expected outcome of Act
                //Equal(number of customers expected, #of customers retrevied from GetAllCustomers)
                Assert.Equal("Username", found.UserName);
            }
        }

        [Fact]
        public void GetUserUserName()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IUserBL BL = new UsersBL(new UserCloudRepo(context));
                Entity.User test = context.Users.Find(1);
                //Act -- a call to the method that is being tested 
                List<Model.User> found = BL.GetUserByName(test.UserName);

                //Assert -- expected outcome of Act
                //Equal(number of customers expected, #of customers retrevied from GetAllCustomers)
                Assert.Equal("Username", found[0].UserName);
            }
        }


        [Fact]
        public void DeleteUserTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //Arrange
                IUserRepo repo = new UserCloudRepo(context);
                Entity.User user = context.Users.Find(2);

                //Act
                repo.DeleteUser(user.Id);
            }
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //Assert
                List<Entity.User> ListOfUser = context.Users.ToList();

                Assert.Single(ListOfUser);
                Assert.Null(context.Users.Find(2));
            }
        }

        [Fact]
        public void AddUserTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IUserRepo repo = new UserCloudRepo(context);
                Model.User AddedUser = new Model.User
                {
                    UserName = "AddTest",
                    UserPass = "WasIAdded",
                    Email = "Add@Test.com",
                    NameOfUser = "tester"
                };

                //Act -- a call to the method that is being tested 
                repo.AddUser(AddedUser);
            }
            //Assert -- expected outcome of Act
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                Entity.User result = context.Users.Find(3);

                Assert.NotNull(result);
                Assert.Equal("AddTest", result.UserName);
            }
        }

        private void Seed()
        {
            //using to block to automaticaly close the resorce that is used to connect to this db after seeding data to it
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //delete inmemory database at start to eliminate any previous data and confirm you are workinf in a pristine atabase
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Users.AddRange
                (
                    new Entity.User
                    {
                        UserName = "Username",
                        UserPass = "Password",
                        Email = "mail@myMail.com",
                        NameOfUser = "name"
                    },
                    new Entity.User
                    {
                        UserName = "Traveler",
                        UserPass = "TravelMaster3446",
                        Email = "mail@traveling.com",
                        NameOfUser = "anotherName"
                    }
                );
                context.SaveChanges();
            }
        }
    }

    
}

