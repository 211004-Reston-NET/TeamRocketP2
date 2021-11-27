using System.Collections.Generic;
using System.Linq;
using DL;
using Models;

namespace BL
{
    public class ReplyBL : IReplyBL
    {

        IReplyRepo _repo;

        public ReplyBL(IReplyRepo p_repo)
        {
            _repo = p_repo;
        }
        public Reply AddReply(Reply p_reply)
        {
            return _repo.AddReply(p_reply);
        }

        public Reply DeleteReply(int p_reply_Id)
        {
            return _repo.DeleteReply(p_reply_Id);
        }

        public List<Reply> GetAllReplies()
        {
            return _repo.GetAllReplies();
        }

        public Reply GetReplyById(int p_Id)
        {
            List<Reply> listOfReplies = _repo.GetAllReplies();


            List<Reply> Found = (listOfReplies.Where(reply => reply.ReplyId.Equals(p_Id))).ToList();

            return Found[0];
        }

        public List<Reply> GetReplyByPost(int p_Post_Id)
        {
            List<Reply> listOfReplies = _repo.GetAllReplies();

            return listOfReplies.Where(reply => reply.PostId.Equals(p_Post_Id)).ToList();

        }
    }
}