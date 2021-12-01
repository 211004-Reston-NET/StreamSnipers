using Data_Layer;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository _repo;
        public UserController(IRepository p_repo)
        {
            _repo = p_repo;
        }

        // GET: api/user/all
        [HttpGet("All")]
        public IActionResult GetAllUser()
        {
            return Ok(_repo.GetAllUsers());
        }

        // GET api/user/{id}
        [HttpGet("{p_id}")]
        public IActionResult GetUserById(int p_id)
        {
            return Ok(_repo.GetUserById(p_id));
        }

        // Get api/user/login/{email}/{password}
        [HttpGet("{p_email}/{p_password}")]
        public IActionResult LoginUser(string p_email)
        {
            return Ok(_repo.LoginUser(p_email));
        }

        // POST api/user/add
        [HttpPost("Add")]
        public IActionResult AddUser([FromBody] User value)
        {
            return Created("api/User/Add", _repo.AddUser(value));
        }

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/user/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUserById(int id)
        {
            return Ok(_repo.DeleteUserById(id));
        }
    }
}
