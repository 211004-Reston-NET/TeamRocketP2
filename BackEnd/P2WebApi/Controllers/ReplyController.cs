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
            Log.Logger = new LoggerConfiguration()
              .Enrich.FromLogContext()

              .WriteTo.File(new JsonFormatter(), "Logs/GetReplybyPost.json")

              .CreateLogger();
            try
            {
                Log.Information($"Get reply by Postid: {id} executed");
                return Ok(_ReplyBL.GetReplyByPost(id));

            }
            catch
            {
                Log.Information($"Failed to get Reply with Postid: {id}");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
           
        }

        // GET api/<ReplyController>/5
        [HttpGet("ById{id}")]
        public IActionResult Get(int id)
        {
            Log.Logger = new LoggerConfiguration()
              .Enrich.FromLogContext()

              .WriteTo.File(new JsonFormatter(), "Logs/Getposts.json")

              .CreateLogger();
            try
            {
                Log.Information($"Get reply by id: {id} executed");
                return Ok(_ReplyBL.GetReplyById(id));

            }
            catch
            {
                Log.Information($"Failed to get Reply with id: {id}");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }

        // POST api/<ReplyController>
        [HttpPost("Add")]
        public IActionResult AddReply([FromBody] Reply reply)
        {
            Log.Logger = new LoggerConfiguration()
              .Enrich.FromLogContext()

              .WriteTo.File(new JsonFormatter(), "Logs/AddReply.json")

              .CreateLogger();
            try
            {
                Log.Information("Add Reply was executed");
                return Created("api/Reply/Add", _ReplyBL.AddReply(reply));

            }
            catch
            {
                Log.Information("Failed to Add Reply");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
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
            Log.Logger = new LoggerConfiguration()
              .Enrich.FromLogContext()

              .WriteTo.File(new JsonFormatter(), "Logs/DeleteReply.json")

              .CreateLogger();
            try
            {
                Log.Information("Delete Reply was executed");
                return Ok(_ReplyBL.DeleteReply(id));

            }
            catch
            {
                Log.Information("Failed to Delete Reply");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }
    }
}