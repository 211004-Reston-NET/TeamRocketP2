using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Entity = DL.Entities;
using Model = Models;

namespace DL
{
    public class InviteCloudRepo : IInviteRepo
    {
        private Entity.P3ApiContext _context;

       // not sure if this is correct
        public InviteCloudRepo(Entity.P3ApiContext p_context)
        {
            _context = p_context;
        }
        public Model.Invite AddInvite(Model.Invite p_invite)
        {
            _context.Invites.Add
            (
                new Entity.Invite()
                {
                    UserId = p_invite.UserId,
                    EmailRecipient = p_invite.EmailRecipient,
                    EventId = p_invite.EventId, 
                    
                }
            );
            _context.SaveChanges();
            return p_invite;
        }

        public List<Model.Invite> GetAllInvite()
        {
            return _context.Invites.Select(Invite =>
                new Model.Invite()
                {
                    InviteId =  Invite.InviteId,
                    UserId = Invite.UserId,
                    EmailRecipient = Invite.EmailRecipient,
                    EventId = Invite.EventId 
                    
                }
            ).ToList();

        }

      

         public Model.Invite DeleteInvite(Model.Invite p_invite)
        {
           _context.Invites.Remove(
               new Entity.Invite()

               {
                    InviteId = p_invite.InviteId,
                    UserId = p_invite.UserId,
                    EmailRecipient = p_invite.EmailRecipient,
                    EventId = p_invite.EventId, 
                    
                }
           ); 


           _context.SaveChanges();
           return p_invite;
        }

        public Invite GetInviteById(int p_inviteId)
        {
            throw new NotImplementedException();
        }

        public Invite UpdateInviteById(int p_inviteId)
        {
            throw new NotImplementedException();
        }
    }

}