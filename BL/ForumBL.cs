using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class ForumBL : IForumBL

    {
        IForumRepo _repo;

        public ForumBL(IForumRepo p_repo)
        {
            _repo = p_repo;
        }
        public Forum AddForum(Forum p_forum)
        {
            return _repo.AddForum(p_forum);
        }

        public List<Forum> GetAllForum()
        {
            return _repo.GetAllForum();
        }

        
        
        public Forum GetForumById(int p_forumId)
        {
            List<Forum> listOfForum = _repo.GetAllForum();


            List<Forum> Found = (listOfForum.Where(forum => forum.ForumId.Equals(p_forumId))).ToList();

            return Found[0];
        }

        public Forum DeleteForum(Forum p_forum)
        {
            return _repo.DeleteForum(p_forum);
        }
    }
}