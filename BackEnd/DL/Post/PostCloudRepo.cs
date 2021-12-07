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

        public Model.Post DeletePost(int p_Id)
        {
        
            var result = _context.Posts
                .FirstOrDefault<Entity.Post>(post =>
                    post.PostId == p_Id);
            _context.Posts.Remove(result);
            _context.SaveChanges();

            return new Model.Post()
            {
                PostText = result.PostText,
                DateCreated = result.DateCreated,
                UserId = result.UserId,
                ForumId = result.ForumId,
                PostId = result.PostId
            };
        }

        public List<Model.Post> GetAllPosts()
        {
            DateTime localDate = DateTime.Now;
            return _context.Posts.Select(post =>
                new Model.Post()
                {
                    PostText = post.PostText,
                    DateCreated = localDate.ToString(),
                    UserId = post.UserId,
                    ForumId = post.ForumId,
                    PostId = post.PostId
                }
            ).ToList();
        }
    }
}