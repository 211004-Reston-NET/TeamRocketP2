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
    public class ForumTest
    {

        private readonly DbContextOptions<DL.Entities.P3ApiContext> _options;

        public ForumTest()
        {
            _options = new DbContextOptionsBuilder<DL.Entities.P3ApiContext>()
                        .UseSqlite("Filename =ForumTest.db").Options;

            Seed();
        }
        [Fact]
        public void ShouldGetAllForums()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IForumRepo repo = new ForumCloudRepo(context);

                //Act -- a call to the method that is being tested 
                List<Model.Forum> test = repo.GetAllForum();

                //Assert -- expected outcome of Act
                Assert.Equal(2, test.Count);
                Assert.Equal("Topic Name", test[0].TopicName);
            }

        }

        [Fact]
        public void GetForumByIdTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IForumBL BL = new ForumBL(new ForumCloudRepo(context));
                Entity.Forum test = context.Forums.Find(1);
                //Act -- a call to the method that is being tested 
                Model.Forum found = BL.GetForumById(test.ForumId);

                //Assert -- expected outcome of Act
                Assert.Equal(2, found.CreatorId);
            }
        }

      

        [Fact]
        public void DeleteForumTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //Arrange
                IForumRepo repo = new ForumCloudRepo(context);
                Entity.Forum Forum = context.Forums.Find(2);

                //Act
                repo.DeleteForum(Forum.ForumId);
            }
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //Assert
                List<Entity.Forum> ListOfForum = context.Forums.ToList();

                Assert.Single(ListOfForum);
                Assert.Null(context.Forums.Find(2));
            }
        }

        [Fact]
        public void AddForumTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IForumRepo repo = new ForumCloudRepo(context);
                Model.Forum AddedForum = new Model.Forum
                {
                    
                       CreatorId = 1,
                       TopicName = "Topic Name",
                       DateCreated = "1/1/2021",
                       AmountOfPosts = 1
                      
                };

                //Act -- a call to the method that is being tested 
                repo.AddForum(AddedForum);
            }
            //Assert -- expected outcome of Act
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                Entity.Forum result = context.Forums.Find(3);

                Assert.NotNull(result);
                Assert.Equal("Topic Name", result.TopicName);
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

            
          

              
                context.Forums.AddRange
               (
                   new Entity.Forum
                   {
                       CreatorId = 1,
                       TopicName = "Topic Name",
                       DateCreated = "1/1/2021",
                       AmountOfPosts = 1
                      
                   },
                   new Entity.Forum
                   {
                        CreatorId = 2,
                       TopicName = "Topic Names",
                       DateCreated = "2/1/2021",
                       AmountOfPosts = 2
                   }
               );
                context.SaveChanges();
            }
            }
    }
}
            
        