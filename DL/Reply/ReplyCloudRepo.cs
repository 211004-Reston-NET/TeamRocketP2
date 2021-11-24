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
            _context.Replies.Add
            (
                new Entity.Reply()
                {
                    ReplyText = p_reply.ReplyText,
                    DateCreated = p_reply.DateCreated,
                    UserId = p_reply.UserId,
                    PostId = p_reply.PostId
                }
            );
            _context.SaveChanges();
            return p_reply;
        }

        public Model.Reply DeleteReply(Model.Reply p_reply)
        {
            _context.Replies.Remove
            (
                new Entity.Reply()
                {
                    ReplyText = p_reply.ReplyText,
                    DateCreated = p_reply.DateCreated,
                    UserId = p_reply.UserId,
                    PostId = p_reply.PostId,
                    ReplyId = p_reply.ReplyId
                }
            );
            _context.SaveChanges();
            return p_reply;
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