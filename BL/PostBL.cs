using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class PostBL : IPostBL

    {
        IPostRepo _repo;

        public PostBL(IPostRepo p_repo)
        {
            _repo = p_repo;
        }
        public Post AddPost(Post p_post)
        {
            return _repo.AddPost(p_post);
        }

        public List<Post> GetAllPost()
        {
            return _repo.GetAllPost();
        }

        
        
        public Post GetPostById(int p_postId)
        {
            List<Post> listOfPost = _repo.GetAllPost();


            List<Post> Found = (listOfPost.Where(eve => eve.PostId.Equals(p_postId))).ToList();

            return Found[0];
        }

        public Post DeletePost(Post p_post)
        {
            return _repo.DeletePost(p_post);
        }
    }
}