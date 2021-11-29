using System;
using Xunit;
using Model = Models;
using Entity = DL.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DL;

namespace ApiTest
{
    public class UserTest
    {

        private readonly DbContextOptions<DL.Entities.P3ApiContext> _options;

        public UserTest()
        {
            _options = new DbContextOptionsBuilder<DL.Entities.P3ApiContext>()
                        .UseSqlite("Filename =Test.db").Options;
                    
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

