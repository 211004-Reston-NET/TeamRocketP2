using System;
using System.Collections.Generic;
using System.Linq;
using Models;
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
            DateTime localDate = DateTime.Now;

            _context.Forums.Add
            (
                new Entity.Forum()
                {
                    TopicName = p_forum.TopicName,
                    DateCreated = localDate.ToString(),
                    CreatorId = p_forum.CreatorId, 
                    AmountOfPosts = p_forum.AmountOfPosts,
                    
                }
            );
            _context.SaveChanges();
            return p_forum;
        }

        public List<Model.Forum> GetAllForum()
        {
            return _context.Forums.Select(Forum =>
                new Model.Forum()
                {
                    ForumId =  Forum.ForumId,
                    TopicName = Forum.TopicName,
                    DateCreated = Forum.DateCreated,
                    CreatorId = Forum.CreatorId, 
                    AmountOfPosts = Forum.AmountOfPosts,
                    
                }
            ).ToList();

        }

       
         public Model.Forum DeleteForum(int p_forum_Id)
        {
          
            var result = _context.Forums
                .FirstOrDefault<Entity.Forum>(fourm =>
                    fourm.ForumId == p_forum_Id);
            _context.Forums.Remove(result);
            _context.SaveChanges();

            return new Model.Forum()

               {
                    ForumId = result.ForumId,
                    TopicName = result.TopicName,
                    DateCreated = result.DateCreated,
                    CreatorId = result.CreatorId, 
                    AmountOfPosts = result.AmountOfPosts,
                    
                };
            


           
        }

        public Forum GetForumById(int p_forumId)
        {
            throw new NotImplementedException();
        }

        public Forum UpdateForumById(int p_forumId)
        {
            throw new NotImplementedException();
        }
    }

}