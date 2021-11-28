using System.Collections.Generic;
using Models;

namespace BL
{
    public interface IReplyBL
    {
        List<Reply> GetAllReplies();


        Reply AddReply(Reply _reply);


        List<Reply> GetReplyByPost(int _Post_Id);


        Reply GetReplyById(int _Id);


        Reply DeleteReply(int _reply_Id);
    }
}