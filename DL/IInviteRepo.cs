using System.Collections.Generic;
using Models;
namespace DL
{
    public interface IInviteRepo
    {
         /// <summary>
        /// will return a list of Invite
        /// </summary>
        /// <returns></returns>
        List<Invite> GetAllInvite();

        /// <summary>
        /// Adds passed Invite to the database
        /// </summary>
        /// <param name="p_invite"></param>
        /// <returns>added user</returns>
        Invite AddInvite(Invite p_invite);

         /// <summary>
        /// It will grab any Invite from the database by it's Id
        /// </summary>
        /// <param name="p_inviteId">This is the Id that will be assigned to the Invite</param>
        /// <returns>It returns the Invite by Id</returns>

        Invite GetInviteById(int p_inviteId);

        Invite UpdateInviteById(int p_inviteId);

 /// <summary>
        /// It will delete an Invite from the database
        /// </summary>
        /// <param name="p_invite">This is the Invite it will delete</param>
        /// <returns>It returns the deleted Invite</returns>
        Invite DeleteInvite(Invite p_invite);

        
    }
}