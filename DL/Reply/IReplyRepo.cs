using System.Collections.Generic;
using Models;
namespace DL
{
    public interface IReplyRepo
    {
        /// <summary>
        /// will return a list of replies
        /// </summary>
        /// <returns></returns>
        List<Reply> GetAllReplies();

        /// <summary>
        /// adds passed user
        /// </summary>
        /// <param name="_relpy"></param>
        /// <returns></returns>
        Reply AddReply(Reply _relpy);

        /// <summary>
        /// delete passed reply
        /// </summary>
        /// <param name="_reply"></param>
        /// <returns></returns>
        Reply DeleteReply(int _reply_Id);
    }
}