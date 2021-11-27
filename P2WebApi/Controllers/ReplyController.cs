using BL;
using Microsoft.AspNetCore.Mvc;
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
    public class ReplyController : ControllerBase
    {
        private readonly IReplyBL _ReplyBL;

        public ReplyController(IReplyBL p_replyBL)
        {
            _ReplyBL = p_replyBL;
        }
        // GET: api/<ReplyController>
        [HttpGet("ByPost{id}")]
        public IActionResult GetReplysByPost(int id)
        {
            return Ok(_ReplyBL.GetReplyByPost(id));
        }

        // GET api/<ReplyController>/5
        [HttpGet("ById{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_ReplyBL.GetReplyById(id));
        }

        // POST api/<ReplyController>
        [HttpPost("Add")]
        public IActionResult AddPost([FromBody] Reply reply)
        {
            return Created("api/Reply/Add",_ReplyBL.AddReply(reply));
        }

        // PUT api/<ReplyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReplyController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteReply(int id)
        {
            return Ok(_ReplyBL.DeleteReply(id));
        }
    }
}
