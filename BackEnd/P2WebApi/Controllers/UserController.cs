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
            return Ok(_userBL.GetAllUsers());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userBL.GetUserById(id));
        }


        [HttpGet("Verify{email}")]
        public IActionResult VerifyUser(string email)
        {
            User user = _userBL.GetUserByEmail(email);
            if(user.Email != email)
                {return Ok(_userBL.AddUserFromAuth0(email));}
        
            return Ok(user);
        }

        [HttpGet("ByEmail{email}")]
        public IActionResult UserByEmail(string email)
        {
            return Ok(_userBL.GetUserByEmail(email)); 
        }

        // POST api/<UserController>
        [HttpPost("Add")]
        public IActionResult AddUser([FromBody] User p_user)
        {
            return Created("api/User/Add", _userBL.AddUser(p_user));
        }


        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(_userBL.DeleteUser(id));
        }
    }
}
