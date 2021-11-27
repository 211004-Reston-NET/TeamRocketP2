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
    public class PostController : ControllerBase
    {
        private readonly IPostBL _post;

        public PostController(IPostBL p_post)
        {
            _post = p_post;
        }
        // GET: api/<PostController>
        [HttpGet("ByForum{id}")]
        public IActionResult GetPostByForum(int id)
        {
            return Ok(_post.GetPostByForum(id));
        }

        // GET api/<PostController>/5
        [HttpGet("ById{id}")]
        public IActionResult GetPostById(int id)
        {
            return Ok(_post.GetPostById(id));
        }

        // POST api/<PostController>
        [HttpPost("Add")]
        public IActionResult Post([FromBody] Post p_post)  
        {
            return Created("api/Post/Add", _post.AddPost(p_post));
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_post.DeletePost(id));
        }
    }
}
