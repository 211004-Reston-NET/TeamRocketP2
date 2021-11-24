using System.Collections.Generic;
using System.Linq;
using DL;
using Models;


namespace BL
{
    public class PostBL : IPostBL
    {

        IPostRepo _repo;

        public PostBL(IPostRepo p_repo)
        {
            _repo=p_repo;
        }
        public Post AddPost(Post p_post)
        {
            return _repo.AddPost(p_post);
        }

        public Post DeletePost(Post p_post)
        {
            return _repo.DeletePost(p_post);
        }

        public List<Post> GetAllPosts()
        {
            return _repo.GetAllPosts();
        }

        public Post GetPostById(int p_Id)
        {
            List<Post> listOfPosts = _repo.GetAllPosts();


            List<Post> Found = (listOfPosts.Where(post => post.PostId.Equals(p_Id))).ToList();

            return Found[0];
        }

        public List<Post> GetPostByForum(int p_forum_Id)
        {
            throw new System.NotImplementedException();
        }
    }
}