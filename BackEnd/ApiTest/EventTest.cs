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
    public class EventTest
    {

        private readonly DbContextOptions<DL.Entities.P3ApiContext> _options;

        public EventTest()
        {
            _options = new DbContextOptionsBuilder<DL.Entities.P3ApiContext>()
                        .UseSqlite("Filename =EventTest.db").Options;

            Seed();

        }
        [Fact]
        public void ShouldGetAllEvents()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IEventRepo repo = new EventCloudRepo(context);

                //Act -- a call to the method that is being tested 
                List<Model.Event> test = repo.GetAllEvent();

                //Assert -- expected outcome of Act
                Assert.Equal(2, test.Count);
                Assert.Equal("We Japanese", test[1].EventName);
            }

        }

        [Fact]
        public void GetEventByIdTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IEventBL BL = new EventBL(new EventCloudRepo(context));
                Entity.Event test = context.Events.Find(1);
                //Act -- a call to the method that is being tested 
                Model.Event found = BL.GetEventById(test.EventId);

                //Assert -- expected outcome of Act
                Assert.Equal(1, found.EventId);
            }
        }


        [Fact]
        public void DeleteEventTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //Arrange
                IEventRepo repo = new EventCloudRepo(context);
                Entity.Event Event = context.Events.Find(2);

                //Act
                repo.DeleteEvent(Event.EventId);
            }
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //Assert
                List<Entity.Event> ListOfEvent = context.Events.ToList();

                Assert.Single(ListOfEvent);
                Assert.Null(context.Events.Find(2));
            }
        }

        [Fact]
        public void AddEventTest()
        {
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IEventRepo repo = new EventCloudRepo(context);
                Model.Event AddedEvent = new Model.Event
                {
                    StartTime = "10:30",
                    EndTime = "11:30",
                    StartDate = "11/10/2021",
                    EndDate = "11/11/2021",
                    Location = "Tokyo",
                    EventName = "We Love Japan",
                    EventDescription = "Japan fun"
                };

                //Act -- a call to the method that is being tested 
                repo.AddEvent(AddedEvent);
            }
            //Assert -- expected outcome of Act
            using (var context = new DL.Entities.P3ApiContext(_options))
            {
                Entity.Event result = context.Events.Find(3);

                Assert.NotNull(result);
                Assert.Equal("Tokyo", result.Location);
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

                context.Events.AddRange
               (
                   new Entity.Event
                   {
                       StartTime = "11:30",
                       EndTime = "12:30",
                       StartDate = "11/12/2021",
                        EndDate = "11/12/2021",
                       Location = "Tokyoooo",
                       EventName = "We Love Japanese",
                       EventDescription = "Japan funnnnn"
                   },
                   new Entity.Event
                   {
                       StartTime = "9:30",
                       EndTime = "10:30",
                       StartDate = "11/10/2021",
                       EndDate = "11/11/2021",
                       Location = "kyoooo",
                       EventName = "We Japanese",
                       EventDescription = "funnnnn"
                   }
               );
                context.SaveChanges();


            }
        }
    }


}