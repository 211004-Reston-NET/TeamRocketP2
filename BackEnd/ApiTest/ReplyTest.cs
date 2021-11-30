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
    public class ReplyTest
    {

        private readonly DbContextOptions<DL.Entities.P3ApiContext> _options;

        public ReplyTest()
        {
            _options = new DbContextOptionsBuilder<DL.Entities.P3ApiContext>()
                        .UseSqlite("Filename =ReplyTest.db").Options;

            Seed();
        }
        [Fact]
        public void ShouldGetAllReplys()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IReplyRepo repo = new ReplyCloudRepo(context);

                //Act -- a call to the method that is being tested 
                List<Model.Reply> test = repo.GetAllReplies();

                //Assert -- expected outcome of Act
                Assert.Equal(2, test.Count);
                Assert.Equal(2, test[0].UserId);
            }

        }

        [Fact]
        public void GetReplyByIdTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IReplyBL BL = new ReplyBL(new ReplyCloudRepo(context));
                Entity.Reply test = context.Replies.Find(2);
                //Act -- a call to the method that is being tested 
                Model.Reply found = BL.GetReplyById(test.ReplyId);

                //Assert -- expected outcome of Act
                Assert.Equal("I disagree", found.ReplyText);
            }
        }

        [Fact]
        public void GetReplyByPost()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IReplyBL BL = new ReplyBL(new ReplyCloudRepo(context));
                Entity.Reply test = context.Replies.Find(1);
                //Act -- a call to the method that is being tested 
                List<Model.Reply> found = BL.GetReplyByPost(test.PostId);

                //Assert -- expected outcome of Act
                Assert.Equal("You are Wrong", found[0].ReplyText);
            }
        }


        [Fact]
        public void DeleteReplyTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //Arrange
                IReplyRepo repo = new ReplyCloudRepo(context);
                Entity.Reply Reply = context.Replies.Find(2);

                //Act
                repo.DeleteReply(Reply.ReplyId);
            }
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //Assert
                List<Entity.Reply> ListOfReply = context.Replies.ToList();

                Assert.Single(ListOfReply);
                Assert.Null(context.Replies.Find(2));
            }
        }

        [Fact]
        public void AddReplyTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IReplyRepo repo = new ReplyCloudRepo(context);
                Model.Reply AddedReply = new Model.Reply
                {
                    ReplyText = "this was great",
                    DateCreated = "11/31/19",
                    UserId = 1,
                    PostId = 2,
                };

                //Act -- a call to the method that is being tested 
                repo.AddReply(AddedReply);
            }
            //Assert -- expected outcome of Act
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                Entity.Reply result = context.Replies.Find(3);

                Assert.NotNull(result);
                Assert.Equal("this was great", result.ReplyText);
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
                       TopicName = "topic1",
                       DateCreated = "date",
                       CreatorId = 1,
                       AmountOfPosts = 4,
                   },
                   new Entity.Forum
                   {
                       TopicName = "topic2",
                       DateCreated = "date2",
                       CreatorId = 2,
                       AmountOfPosts = 3,
                   }
               );
                context.SaveChanges();

                context.Posts.AddRange
                (
                    new Entity.Post
                    {
                        PostText = "this was very fun",
                        DateCreated = "11/29/19",
                        UserId = 1,
                        ForumId = 2

                    },
                    new Entity.Post
                    {
                        PostText = "this was terrible",
                        DateCreated = "11/29/19",
                        UserId = 2,
                        ForumId = 1
                    }
                );
                context.SaveChanges();

                context.Replies.AddRange
               (
                   new Entity.Reply
                   {
                       ReplyText = "I disagree",
                       DateCreated = "11/30/19",
                       UserId = 1,
                       PostId = 2,
               

                   },
                   new Entity.Reply
                   {
                       ReplyText = "You are Wrong",
                       DateCreated = "11/30/19",
                       UserId = 2,
                       PostId = 1,
                   }
               );
                context.SaveChanges();
            }
        }
    }


}

