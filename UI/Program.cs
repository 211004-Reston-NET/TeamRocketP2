using System;
using System.Collections.Generic;
using System.IO;
using BL;
using DL;
using DL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model = Models;

namespace UI
{
    class Program
    {
      
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();
            DbContextOptions<P3ApiContext> options = new DbContextOptionsBuilder<P3ApiContext>()
                .UseSqlServer(config.GetConnectionString("ReferenceToDB"))
                .Options;
            
            Console.WriteLine("Hello World!");

            var instance = new ConsoleTesting(new UsersBL(new UserCloudRepo(new P3ApiContext(options))));
            //instance.TestAdd();
            // List<Model.User> ListOfUsers= instance.TestShowAll();
            // List<Model.User> ListOfUsers = instance.TestGetByName("name");
            // foreach(Models.User user in ListOfUsers)
            // {
            //     Console.WriteLine(user.ToString());
            // }

            // foreach (Models.User user in ListOfUsers)
            // {
            //     Console.WriteLine(user.ToString());
            // }

            //Console.WriteLine(instance.TestGetByID(1));

            //instance.TestDeleteUser(instance.TestGetByID(1));
        }

        
    }
}
