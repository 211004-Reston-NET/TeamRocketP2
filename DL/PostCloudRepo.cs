using System;
using System.Collections.Generic;
using System.Linq;
using Entity = DL.Entities;
using Model = Models;

namespace DL
{
    public class PostCloudRepo : IPostRepo
    {
        private Entity.P3ApiContext _context;

       // not sure if this is correct
        public PostCloudRepo(Entity.P3ApiContext p_context)
        {
            _context = p_context;
        }
        public Model.Post AddPost(Model.Post p_post)
        {
            _context.Post.Add
            (
                new Entity.Post()
                {
                    PostText = p_post.PostText,
                    DateCreated = p_post.DateCreated,
                    UserId = p_post.UserId, 
                    ForumId = p_post.ForumId,
                    
                }
            );
            _context.SaveChanges();
            return p_post;
        }

        public List<Model.Post> GetAllPost()
        {
            return _context.Post.Select(Post =>
                new Model.Post()
                {
                    PostId =  Post.PostId,
                    PostText = Post.PostText,
                    DateCreated = Post.DateCreated,
                    UserId = Post.UserId, 
                    ForumId = Post.ForumId,
                    
                }
            ).ToList();

        }

    

         public Model.Post DeletePost(Model.Post p_post)
        {
           _context.Post.Remove(
               new Entity.Post()

               {
                    PostId = p_post.PostId,
                    PostText = p_post.PostText,
                    DateCreated = p_post.DateCreated,
                    UserId = p_post.UserId, 
                    ForumId = p_post.ForumId,
                    
                }
           ); 


           _context.SaveChanges();
           return p_post;
        }

     
    }

}