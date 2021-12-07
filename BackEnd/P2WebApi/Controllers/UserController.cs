using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Serilog;
using Serilog.Formatting.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P2WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBL;

        public UserController(IUserBL p_userBL)
        {
            _userBL = p_userBL;
        }
        // GET: api/<UserController>
        [HttpGet("All")]
        public IActionResult GetAllUsers()
        {
            Log.Logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .WriteTo.File(new JsonFormatter(), "Logs/GetUsers.json")
               .CreateLogger();
            try
            {
                Log.Information("Get All Users was executed");
                return Ok(_userBL.GetAllUsers());
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

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            Log.Logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .WriteTo.File(new JsonFormatter(), "Logs/GetUserbyId.json")
               .CreateLogger();
            try
            {
                Log.Information("Get User by id was executed");
                return Ok(_userBL.GetUserById(id));
            }
            catch
            {
                Log.Information($"Failed to get user with id: {id} events");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }


        [HttpGet("Verify{email}")]
        public IActionResult VerifyUser(string email)
        {
   
            User user = _userBL.GetUserByEmail(email);
            if(user.Email != email)
            { return Ok(_userBL.AddUserFromAuth0(email)); }

            return Ok(user);
          
        }

        [HttpGet("ByEmail{email}")]
        public IActionResult UserByEmail(string email)
        {

            Log.Logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .WriteTo.File(new JsonFormatter(), "Logs/GetByEmail.json")
               .CreateLogger();
            try
            {
                Log.Information("Get user by email was executed");
                return Ok(_userBL.GetUserByEmail(email));

            }
            catch
            {
                Log.Information($"Failed to get User by Email: {email}");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }

        // POST api/<UserController>
        [HttpPost("Add")]
        public IActionResult AddUser([FromBody] User p_user)
        {
            Log.Logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .WriteTo.File(new JsonFormatter(), "Logs/Adduser.json")
               .CreateLogger();
            try
            {
                Log.Information("Add user was executed");
                return Created("api/User/Add", _userBL.AddUser(p_user));

            }
            catch
            {
                Log.Information("Failed to Add User");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }


        // [HttpPut("Update{id}")]
        // public IActionResult UpdateUser(int id, [FromBody]User p_user)
        // {
        //     //return Ok( _userBL.UpdateUser(p_user));
        //     return Created("api/User/Update", _userBL.UpdateUser(p_user));
        // }

        [HttpPut("Update")]
        public IActionResult UpdateUser( [FromBody] User p_user)
        {
            //return Ok( _userBL.UpdateUser(p_user));
            return Created("api/User/Update", _userBL.UpdateUser(p_user));
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            Log.Logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .WriteTo.File(new JsonFormatter(), "Logs/DeleteUser.json")
               .CreateLogger();
            try
            {
                Log.Information("User Delete was executed");
                return Ok(_userBL.DeleteUser(id));

            }
            catch
            {
                Log.Information("Failed to Delete User");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }
    }
}