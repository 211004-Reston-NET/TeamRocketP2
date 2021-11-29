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
    public class ForumController : ControllerBase
    {
        //Dependency injection
        private readonly IForumBL _ForumBL;

        public ForumController(IForumBL p_ForumBL)
        {
            _ForumBL = p_ForumBL;
        }

        [HttpGet("{p_id}")]
        public IActionResult GetForumById(int p_id)
        {
            return Ok(_ForumBL.GetForumById(p_id));
        }


         [HttpPost("Add")]
        public IActionResult AddFourm([FromBody] Forum p_fourm)
        {
            return Created("api/Forum/Add", _ForumBL.AddForum(p_fourm));
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeleteFourm(int id)
        {
            return Ok(_ForumBL.DeleteForum(id));
        }

    }
}