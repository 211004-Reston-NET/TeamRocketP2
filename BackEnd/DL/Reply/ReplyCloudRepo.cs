using System.Collections.Generic;
using System.Linq;
using Models;
using Entity = DL.Entities;
using Model = Models;

namespace DL
{
    public class ReplyCloudRepo : IReplyRepo
    {
        private Entity.P3ApiContext _context;

        public ReplyCloudRepo(Entity.P3ApiContext p_context)
        {
            _context = p_context;
        }

        public Model.Reply AddReply(Model.Reply p_reply)
        {
            DateTime localDate = DateTime.Now;
            _context.Replies.Add
            (
                new Entity.Reply()
                {
                    ReplyText = p_reply.ReplyText,
                    DateCreated = localDate.ToString(),
                    UserId = p_reply.UserId,
                    PostId = p_reply.PostId
                }
            );
            _context.SaveChanges();
            return p_reply;
        }

        public Model.Reply DeleteReply(int p_reply_Id)
        {
  
            var result = _context.Replies
                .FirstOrDefault<Entity.Reply>(reply =>
                    reply.ReplyId == p_reply_Id);
            _context.Replies.Remove(result);
            _context.SaveChanges();

            return new Model.Reply()
            {
                ReplyText = result.ReplyText,
                DateCreated = result.DateCreated,
                UserId = result.UserId,
                PostId = result.PostId,
                ReplyId = result.ReplyId
            };
        }

        public List<Model.Reply> GetAllReplies()
        {
            return _context.Replies.Select(reply =>
                new Model.Reply()
                {
                    ReplyText = reply.ReplyText,
                    DateCreated = reply.DateCreated,
                    UserId = reply.UserId,
                    PostId = reply.PostId,
                    ReplyId = reply.ReplyId
                }
            ).ToList();
        }
    }
}