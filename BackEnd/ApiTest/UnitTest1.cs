using System;
using Xunit;
using Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiTest
{
    public class UserTest
    {

        // private readonly DbContextOptions<DL.Entities.P3ApiContext> _options;

        // public UserTest()
        // {
        //     _options = new DbContextOptionsBuilder<DL.Entities.P3ApiContext>()
        //                 .UseSqlite("Filename =Test.db").Options;
        //     Seed();
        // }
        [Fact]
        public void ShouldGetAllUsers()
        {
            //Arrange
            List<User> ListOfUsers = new List<User>();

            //Act


            //Assert


        }
    }

    // private void Seed()
    // {
    //     //using to block to automaticaly close the resorce that is used to connect to this db after seeding data to it
    //     using (var context = new DL.Entities.P3ApiContext(_options))
    //     {
    //         //delete inmemory database at start to eliminate any previous data and confirm you are workinf in a pristine atabase
    //         context.Database.EnsureDeleted();
    //         context.Database.EnsureCreated();

    //         // context.Users.AddRange
    //         // (
    //         //     new User
    //         //     {
    //         //         Name = "Tester Balthezar",
    //         //         Address = "754 location dr",
    //         //         EmailPhone = "B@lthezar.com"
    //         //     },
    //         //     new Customer
    //         //     {
    //         //         Name = "Tester Alister",
    //         //         Address = "34 location ave",
    //         //         EmailPhone = "test@Customer.com"
    //         //     }
    //         // );
    //         context.SaveChanges();
    //     }
    // }
}

