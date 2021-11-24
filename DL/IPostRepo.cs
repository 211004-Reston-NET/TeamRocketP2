using System.Collections.Generic;
using Models;
namespace DL
{
    public interface IPostRepo
    {
         /// <summary>
        /// will return a list of Post
        /// </summary>
        /// <returns></returns>
        List<Post> GetAllPost();

        /// <summary>
        /// Adds passed Post to the database
        /// </summary>
        /// <param name="p_post"></param>
        /// <returns>added user</returns>
        Post AddPost(Post p_post);

         /// <summary>
        /// It will grab any Post from the database by it's Id
        /// </summary>
        /// <param name="p_postId">This is the Id that will be assigned to the Post</param>
        /// <returns>It returns the Post by Id</returns>

        Post GetPostById(int p_postId);

        Post UpdatePostById(int p_postId);

 /// <summary>
        /// It will delete an Post from the database
        /// </summary>
        /// <param name="p_post">This is the Post it will delete</param>
        /// <returns>It returns the deleted Post</returns>
        Post DeletePost(Post p_post);

        
    }
}