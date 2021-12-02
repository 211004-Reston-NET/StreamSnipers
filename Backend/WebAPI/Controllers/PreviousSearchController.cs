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
    public class PreviousSearchController : ControllerBase
    {
        private readonly IRepository _repo;
        public PreviousSearchController(IRepository p_repo)
        {
            _repo = p_repo;
        }

        // GET api/previousSearch/{id}
        [HttpGet("{id}")]
        public IActionResult GetPreviousSearchById(int id)
        {
             Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/GetPreviousSearchByIdlog.json")
                .CreateLogger();

            try
            {
                Log.Information("Get previous search by id success");
                return Ok(_repo.GetPreviousSearchById(id));
            }
            catch
            {
                Log.Information("Get previous search id failed");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // GET api/previousSearch/User/{id}
        [HttpGet("User/{id}")]
        public IActionResult GetPreviousSearchByUserId(int id)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/getprevioussearchbyuseridlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Get previous search by user id success");
                return Ok(_repo.GetPreviousSearchByUserId(id));
            }
            catch
            {
                Log.Information("Get previous search by user id failed");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // POST api/previousSearch/add
        [HttpPost("Add")]
        public IActionResult AddPreviousSearch([FromBody] PreviousSearch value)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/allprevioussearchlog.json")
                .CreateLogger();
            try
            {    
                Log.Information("Added previous search");
                return Created("api/PreviousSearch/Add", _repo.AddPreviousSearch(value));
            }
            catch
            {
                Log.Information("Add previous search by id failed");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        //// PUT api/<PreviousSearchController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/previousSearch/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePreviousSearchById(int id)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/deleteprevioussearchbyidlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Deleted previous search");
                return Ok(_repo.DeletePreviousSearchById(id));
            }
            catch
            {
                Log.Information("Delete previous search failed");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }


        //UPDATE api/update-prevsearch-by-id/{id}
        [HttpPut("update-prevsearch-by-id/{id}")]
        public IActionResult UpdatePreviousSearchById(int id, [FromBody] PreviousSearch prevSearch)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/updateprevioussearchbyidlog.json")
                .CreateLogger();
            try
            {   
                Log.Information("Updated previous search by id");
                var updatePreviousSearch = _repo.UpdatePreviousSearchById(id, prevSearch);
                return Ok(updatePreviousSearch);
            }
            catch
            {
                Log.Information("Update previous search by id failed");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
