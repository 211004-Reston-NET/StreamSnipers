using Data_Layer;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Serilog.Formatting.Json;

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
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/GetAllUserlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Get All user");
                return Ok(_repo.GetAllUsers());
            }
            catch
            {
                Log.Information("Failed Get All User");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // GET api/user/{id}
        [HttpGet("{p_id}")]
        public IActionResult GetUserById(int p_id)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/GetUserByIdlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Get User By Id");
                return Ok(_repo.GetUserById(p_id));
            }
            catch
            {
                Log.Information("Failed Get User By Id");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // Get api/user/login/{email}
        [HttpGet("login/{p_email}")]
        public IActionResult LoginUser(string p_email)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/LoginUserlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Login user");
                return Ok(_repo.LoginUser(p_email));
            }
            catch
            {
                Log.Information("Failed Login user");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // Get api/user/userid/{email}
        [HttpGet("userid/{p_email}")]
        public IActionResult GetUserIdByEmail(string p_email)
        {
            return Ok(_repo.GetUserIdByEmail(p_email));
        }

        // POST api/user/add
        [HttpPost("Add")]
        public IActionResult AddUser([FromBody] User value)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/AddUserlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Add User");
                return Created("api/User/Add", _repo.AddUser(value));
            }
            catch
            {
                Log.Information("Failed Add User");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
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
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/DeleteUserByIdlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Delete User By Id");
                return Ok(_repo.DeleteUserById(id));
            }
            catch
            {
                Log.Information("Failed Delete user By Id");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }


        //UPDATE api/update-user-by-id/{id}
        [HttpPut("update-user-by-id/{id}")]
        public IActionResult UpdateUserById(int id, [FromBody] User user)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/UpdateUserByIdlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Update User By Id");
                var updateUser = _repo.UpdateUserById(id, user);
                return Ok(updateUser);
            }
            catch
            {
                Log.Information("Failed Update User By Id");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }


        //UPDATE api/update-user-by-username/{username}
        [HttpPut("update-user-by-username/{username}")]
        public IActionResult UpdateUserByUsername(string username, [FromBody] User user)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/UpdateUserByUsernamelog.json")
                .CreateLogger();
            try
            {
                Log.Information("Update User by Username");
                var updateUser = _repo.UpdateUserByUsername(username, user);
                return Ok(updateUser);
            }
            catch
            {
                Log.Information("failed Update User By Username");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }


        //UPDATE api/update-user-by-email/{email}
        [HttpPut("update-user-by-email/{email}")]
        public IActionResult UpdateUserByEmail(string email, [FromBody] User user)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/UpdateUserByEmaillog.json")
                .CreateLogger();
            try
            {
                Log.Information("Update User by Email");
                var updateUser = _repo.UpdateUserByEmail(email, user);
                return Ok(updateUser);
            }
            catch
            {
                Log.Information("Failed Update User by email");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
