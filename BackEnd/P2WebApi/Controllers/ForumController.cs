using Microsoft.AspNetCore.Mvc;
using BL;
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
    public class ForumController : ControllerBase
    {
        //Dependency injection
        private readonly IForumBL _ForumBL;

        public ForumController(IForumBL p_ForumBL)
        {
            _ForumBL = p_ForumBL;
        }

         [HttpGet("All")]
        public IActionResult GetAllForum()

         {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/GetAllForums.json")
                .CreateLogger();
            try
            {
                Log.Information("Get All Forums was executed");
                return Ok(_ForumBL.GetAllForum());
            }
            catch
            {
                Log.Information("Failed to get all Forums");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }


        [HttpGet("{p_id}")]
        public IActionResult GetForumById(int p_id)

         {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/GetForumById.json")
                .CreateLogger();
            try
            {
                Log.Information("Get Forum by Id was executed");
                  return Ok(_ForumBL.GetForumById(p_id));
            }
            catch
            {
                Log.Information("Failed to get all forums");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }


         [HttpPost("Add")]
        public IActionResult AddFourm([FromBody] Forum p_fourm)
        {
            return Created("api/Forum/Add", _ForumBL.AddForum(p_fourm));
        }

       [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFourm(int id)
        {
            return Ok(_ForumBL.DeleteForum(id));
        }

    }
}