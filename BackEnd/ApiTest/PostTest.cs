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
    public class PostTest
    {

        private readonly DbContextOptions<DL.Entities.P3ApiContext> _options;

        public PostTest()
        {
            _options = new DbContextOptionsBuilder<DL.Entities.P3ApiContext>()
                        .UseSqlite("Filename =PostTest.db").Options;

            Seed();
        }
        [Fact]
        public void ShouldGetAllPosts()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IPostRepo repo = new PostCloudRepo(context);

                //Act -- a call to the method that is being tested 
                List<Model.Post> test = repo.GetAllPosts();

                //Assert -- expected outcome of Act
                Assert.Equal(2, test.Count);
                Assert.Equal(1, test[1].UserId);
            }

        }

        [Fact]
        public void GetPostByIdTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IPostBL BL = new PostBL(new PostCloudRepo(context));
                Entity.Post test = context.Posts.Find(1);
                //Act -- a call to the method that is being tested 
                Model.Post found = BL.GetPostById(test.PostId);

                //Assert -- expected outcome of Act
                Assert.Equal(1, found.ForumId);
            }
        }

        [Fact]
        public void GetPostByForum()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IPostBL BL = new PostBL(new PostCloudRepo(context));
                Entity.Post test = context.Posts.Find(1);
                //Act -- a call to the method that is being tested 
                List<Model.Post> found = BL.GetPostByForum(test.ForumId);

                //Assert -- expected outcome of Act
                Assert.Equal("this was terrible", found[0].PostText);
            }
        }


        [Fact]
        public void DeletePostTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //Arrange
                IPostRepo repo = new PostCloudRepo(context);
                Entity.Post Post = context.Posts.Find(2);

                //Act
                repo.DeletePost(Post.PostId);
            }
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //Assert
                List<Entity.Post> ListOfPost = context.Posts.ToList();

                Assert.Single(ListOfPost);
                Assert.Null(context.Posts.Find(2));
            }
        }

        [Fact]
        public void AddPostTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IPostRepo repo = new PostCloudRepo(context);
                Model.Post AddedPost = new Model.Post
                {
                    PostText = "Could be better",
                    DateCreated = "10/15/20",
                    UserId = 1,
                    ForumId = 1
                };

                //Act -- a call to the method that is being tested 
                repo.AddPost(AddedPost);
            }
            //Assert -- expected outcome of Act
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                Entity.Post result = context.Posts.Find(3);

                Assert.NotNull(result);
                Assert.Equal("Could be better", result.PostText);
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
            }
        }
    }


}

