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
    public class InviteTest
    {

        private readonly DbContextOptions<DL.Entities.P3ApiContext> _options;

        public InviteTest()
        {
            _options = new DbContextOptionsBuilder<DL.Entities.P3ApiContext>()
                        .UseSqlite("Filename =InviteTest.db").Options;

            Seed();
        }
        [Fact]
        public void ShouldGetAllInvites()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IInviteRepo repo = new InviteCloudRepo(context);

                //Act -- a call to the method that is being tested 
                List<Model.Invite> test = repo.GetAllInvite();

                //Assert -- expected outcome of Act
                Assert.Equal(2, test.Count);
                Assert.Equal("crazy@crazymails.com", test[0].EmailRecipient);
            }

        }

        [Fact]
        public void GetInviteByIdTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IInviteBL BL = new InviteBL(new InviteCloudRepo(context));
                Entity.Invite test = context.Invites.Find(1);
                //Act -- a call to the method that is being tested 
                Model.Invite found = BL.GetInviteById(test.InviteId);

                //Assert -- expected outcome of Act
                Assert.Equal(2, found.UserId);
            }
        }

      

        [Fact]
        public void DeleteInviteTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //Arrange
                IInviteRepo repo = new InviteCloudRepo(context);
                Entity.Invite Invite = context.Invites.Find(2);

                //Act
                repo.DeleteInvite(Invite.InviteId);
            }
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //Assert
                List<Entity.Invite> ListOfInvite = context.Invites.ToList();

                Assert.Single(ListOfInvite);
                Assert.Null(context.Invites.Find(2));
            }
        }

        [Fact]
        public void AddInviteTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IInviteRepo repo = new InviteCloudRepo(context);
                Model.Invite AddedInvite = new Model.Invite
                {
                    
                    EmailRecipient = "crazy@crazymails.com",
                    UserId = 1,
                    EventId = 2,
                };

                //Act -- a call to the method that is being tested 
                repo.AddInvite(AddedInvite);
            }
            //Assert -- expected outcome of Act
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                Entity.Invite result = context.Invites.Find(3);

                Assert.NotNull(result);
                Assert.Equal("crazy@crazymails.com", result.EmailRecipient);
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

                  context.Events.AddRange
               (
                   new Entity.Event
                   {
                       StartTime = "11:30",
                       EndTime = "12:30",
                       Location = "Tokyoooo",
                       EventName = "We Love Japanese",
                       EventDescription = "Japan funnnnn"
                   },
                   new Entity.Event
                   {
                       StartTime = "9:30",
                       EndTime = "10:30",
                       Location = "kyoooo",
                       EventName = "We Japanese",
                       EventDescription = "funnnnn"
                   }
               );
                context.SaveChanges();

              
                context.Invites.AddRange
               (
                   new Entity.Invite
                   {
                       UserId = 1,
                       EventId = 1,
                       EmailRecipient = "crazy@crazymail.com",
                      
                   },
                   new Entity.Invite
                   {
                       UserId = 2,
                       EventId = 1,
                       EmailRecipient = "crazy@crazymails.com",
                   }
               );
                context.SaveChanges();

           
            }
        }
    }


}

