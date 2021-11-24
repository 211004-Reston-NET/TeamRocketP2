using System;
using System.Collections.Generic;
using System.Linq;
using Entity = DL.Entities;
using Model = Models;

namespace DL
{
    public class ForumCloudRepo : IForumRepo
    {
        private Entity.P3ApiContext _context;

       // not sure if this is correct
        public ForumCloudRepo(Entity.P3ApiContext p_context)
        {
            _context = p_context;
        }
        public Model.Forum AddForum(Model.Forum p_forum)
        {
            _context.Forum.Add
            (
                new Entity.Forum()
                {
                    TopicName = p_forum.TopicName,
                    DateCreated = p_forum.DateCreated,
                    CreatorId = p_forum.CreatorId, 
                    AmountOfPosts = p_forum.AmountOfPosts,
                    
                }
            );
            _context.SaveChanges();
            return p_forum;
        }

        public List<Model.Forum> GetAllForum()
        {
            return _context.Forum.Select(Forum =>
                new Model.Forum()
                {
                    ForumId =  Forum.ForumId,
                    TopicName = Forum.TopicName,
                    DateCreated = Forum.DateCreated,
                    CreatorId = Forum.CreatorId, 
                    AmountOfPost = Forum.AmountOfPost,
                    
                }
            ).ToList();

        }

       
         public Model.Forum DeleteForum(Model.Forum p_forum)
        {
           _context.Forum.Remove(
               new Entity.Forum()

               {
                    ForumId = p_forum.ForumId,
                    TopicName = p_forum.TopicName,
                    DateCreated = p_forum.DateCreated,
                    CreatorId = p_forum.CreatorId, 
                    AmountOfPost = p_forum.AmountOfPost,
                    
                }
           ); 


           _context.SaveChanges();
           return p_forum;
        }

      
    }

}