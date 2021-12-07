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
    public class EventController : ControllerBase
    {
        //Dependency injection
        private readonly IEventBL _EventBL;

        public EventController(IEventBL p_EventBL)
        {
            _EventBL = p_EventBL;
        }

        [HttpGet("All")]
        public IActionResult GetAllEvent()
        {


            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(), "Logs/GetAllEvents.json")

                .CreateLogger();
            try
            {
                Log.Information("Get All Events was executed");

                return Ok(_EventBL.GetAllEvent());

            }
            catch
            {
                Log.Information("Failed to get all events");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }



        [HttpGet("{p_id}")]
        public IActionResult GetEventById(int p_id)
        {


            Log.Logger = new LoggerConfiguration()
                            .Enrich.FromLogContext()
                            .WriteTo.File(new JsonFormatter(), "Logs/GetAllEvents.json")
                            .CreateLogger();
            try
            {
                Log.Information("Get Event by id was executed");
                return Ok(_EventBL.GetEventById(p_id));
            }
            catch
            {
                Log.Information("Failed to get all events");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }



        }

        
                

       

        
         [HttpPost("Add")]
        public IActionResult AddEvent([FromBody] Event p_event)
        {
            return Created("api/Event/Add", _EventBL.AddEvent(p_event));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            return Ok(_EventBL.DeleteEvent(id));
        }

    }
}
    