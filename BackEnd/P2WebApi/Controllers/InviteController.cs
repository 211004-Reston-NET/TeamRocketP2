using Microsoft.AspNetCore.Mvc;
using BL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P2WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InviteController : ControllerBase
    {
        //Dependency injection
        private readonly IInviteBL _InviteBL;

        public InviteController(IInviteBL p_InviteBL)
        {
            _InviteBL = p_InviteBL;
        }

        [HttpGet("{p_id}")]
        public IActionResult GetInviteById(int p_id)
        {
            return Ok(_InviteBL.GetInviteById(p_id));
        }


        [HttpPost("Add")]
        public IActionResult AddInvite([FromBody] Invite p_invite)
        {
            return Created("api/Invite/Add", _InviteBL.AddInvite(p_invite));
        }

       
        [HttpDelete("Delete")]
        public IActionResult DeleteInvite([FromBody] Invite p_invite)
        {
            return Ok(_InviteBL.DeleteInvite(p_invite));
        }
    }
}