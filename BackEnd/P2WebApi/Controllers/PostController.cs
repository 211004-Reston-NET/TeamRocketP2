using BL;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Serilog.Formatting.Json;


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
            Log.Logger = new LoggerConfiguration()
             .Enrich.FromLogContext()
             .WriteTo.File(new JsonFormatter(), "Logs/GetAllEvents.json")
             .CreateLogger();
            try
            {
                Log.Information($"Get Posts by Forumid: {id} executed");
                return Ok(_post.GetPostByForum(id));

            }
            catch
            {
                Log.Information($"Failed to get Posts By Forumid: {id}");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }

        // GET api/<PostController>/5
        [HttpGet("ById{id}")]
        public IActionResult GetPostById(int id)
        {
            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.File(new JsonFormatter(), "Logs/GetAllEvents.json")
            .CreateLogger();
            try
            {
                Log.Information($"Get Posts by id: {id} executed");
                return Ok(_post.GetPostById(id));

            }
            catch
            {
                Log.Information($"Failed to get Posts By id: {id}");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }

        // POST api/<PostController>
        [HttpPost("Add")]
        public IActionResult Post([FromBody] Post p_post)  
        {
            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.File(new JsonFormatter(), "Logs/GetAllEvents.json")
            .CreateLogger();
            try
            {
                Log.Information("Add Post executed");
                return Created("api/Post/Add", _post.AddPost(p_post));

            }
            catch
            {
                Log.Information("Failed to Add Post");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
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
            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.File(new JsonFormatter(), "Logs/GetAllEvents.json")
            .CreateLogger();
            try
            {
                Log.Information("Delete Post executed");
                return Ok(_post.DeletePost(id));

            }
            catch
            {
                Log.Information("Failed to delete Post");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }
    }
}
