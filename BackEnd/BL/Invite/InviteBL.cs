using System;
using System.Collections.Generic;
using System.Linq;
using DL;
using Models;

namespace BL
{
    public class InviteBL : IInviteBL

    {
        IInviteRepo _repo;

        public InviteBL(IInviteRepo p_repo)
        {
            _repo = p_repo;
        }
        public Invite AddInvite(Invite p_invite)
        {
            return _repo.AddInvite(p_invite);
        }

        public List<Invite> GetAllInvite()
        {
            return _repo.GetAllInvite();
        }

        
        
        public Invite GetInviteById(int p_inviteId)
        {
            List<Invite> listOfInvite = _repo.GetAllInvite();


            List<Invite> Found = (listOfInvite.Where(eve => eve.InviteId.Equals(p_inviteId))).ToList();

            return Found[0];
        }

        public Invite DeleteInvite(int p_invite_Id)
        {
            return _repo.DeleteInvite(p_invite_Id);
        }

        public Invite UpdateInviteById(int p_inviteId)
        {
            throw new NotImplementedException();
        }
    }
}