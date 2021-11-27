using System.Collections.Generic;
using Models;
namespace DL
{
    public interface IPostRepo
    {
        /// <summary>
        /// will return a list of posts
        /// </summary>
        /// <returns></returns>
        List<Post> GetAllPosts();

        /// <summary>
        /// add passed post
        /// </summary>
        /// <param name="_post"></param>
        /// <returns></returns>
        Post AddPost(Post _post);

        /// <summary>
        /// deletes passed post
        /// </summary>
        /// <param name="_post"></param>
        /// <returns></returns>
        Post DeletePost(int _Id);
    }
}