using System.Collections.Generic;
using Models;

namespace BL
{
    public interface IForumBL
    {
        /// <summary>
        /// will return a list of Forum
        /// </summary>
        /// <returns></returns>
        List<Forum> GetAllForum();

        /// <summary>
        /// Adds passed Forum to the database
        /// </summary>
        /// <param name="p_forum"></param>
        /// <returns>added user</returns>
        Forum AddForum(Forum p_forum);

         /// <summary>
        /// It will grab any Forum from the database by it's Id
        /// </summary>
        /// <param name="p_forumId">This is the Id that will be assigned to the Forum</param>
        /// <returns>It returns the Forum by Id</returns>

        Forum GetForumById(int p_referenceId);

        Forum UpdateForumById(int p_referenceId);

 /// <summary>
        /// It will delete an Forum from the database
        /// </summary>
        /// <param name="p_forum">This is the Forum it will delete</param>
        /// <returns>It returns the deleted Forum</returns>
        Forum DeleteForum(Forum p_forum);

    
    }
}