using System.Collections.Generic;
using Models;

namespace BL
{
    public interface IPostBL
    {
        
        List<Post> GetAllPosts();


        Post AddPost(Post _post);

        
        List<Post> GetPostByForum(int _forum_Id);


        Post GetPostById(int _Id);


        Post DeletePost(Post _post);
    }
}