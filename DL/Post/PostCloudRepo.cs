using System.Collections.Generic;
using System.Linq;
using Models;
using Entity = DL.Entities;
using Model = Models;
namespace DL
{
    public class PostCloudRepo : IPostRepo
    {
        private Entity.P3ApiContext _context;

        public PostCloudRepo( Entity.P3ApiContext p_context)
        {
            _context=p_context;
        }

        public Model.Post AddPost(Model.Post p_post)
        {
            _context.Posts.Add
            (
                new Entity.Post()
                {
                    PostText =p_post.PostText,
                    DateCreated = p_post.DateCreated,
                    UserId = p_post.UserId,
                    ForumId = p_post.ForumId
                }
            );
            _context.SaveChanges();
            return p_post;
        }

        public Model.Post DeletePost(Model.Post p_post)
        {
            _context.Posts.Remove
            (
                new Entity.Post()
                {
                    PostText = p_post.PostText,
                    DateCreated = p_post.DateCreated,
                    UserId = p_post.UserId,
                    ForumId = p_post.ForumId,
                    PostId=p_post.PostId
                }
            );
            _context.SaveChanges();
            return p_post;
        
        }

        public List<Model.Post> GetAllPosts()
        {
            return _context.Posts.Select(post =>
                new Model.Post()
                {
                    PostText = post.PostText,
                    DateCreated = post.DateCreated,
                    UserId = post.UserId,
                    ForumId = post.ForumId,
                    PostId = post.PostId
                }
            ).ToList();
        }
    }
}