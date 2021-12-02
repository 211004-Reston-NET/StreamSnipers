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
    public class RecommendationController : ControllerBase
    {
        private readonly IRepository _repo;
        public RecommendationController(IRepository p_repo)
        {
            _repo = p_repo;
        }

        // GET api/recommendation/{id}
        [HttpGet("{id}")]
        public IActionResult GetRecommendationById(int id)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/GetRecommendationByIdlog.json")
                .CreateLogger();
            try
            {    
                Log.Information("");
                return Ok(_repo.GetRecommendationById(id));
            }
            catch
            {
                Log.Information("");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // GET api/recommendation/user/{id}
        [HttpGet("User/{id}")]
        public IActionResult GetRecommendationByUserId(int id)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/GetRecommendationByUserIdlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Get Recommendation By User id");
                return Ok(_repo.GetRecommendationByUserId(id));
            }
            catch
            {
                Log.Information("Failed getting recommendation by user id");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // POST api/recommendation/add
        [HttpPost("Add")]
        public IActionResult AddRecommendation([FromBody] Recommendation value)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/AddRecommendationlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Adding Recommendation");
                return Created("api/Recommendation/Add", _repo.AddRecommendation(value));
            }
            catch
            {
                Log.Information("Failed adding recommendation");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        //// PUT api/<RecommendationController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/recommendation/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteRecommendationById(int id)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/DeleteRecommendationByIdlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Deleting Recommendation by id");
                return Ok(_repo.DeleteRecommendationById(id));
            }
            catch
            {
                Log.Information("Failed Deleting Recommendation by id");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }


        //UPDATE api/update-recommendation-by-id/{id}
        [HttpPut("update-recommendation-by-id/{id}")]
        public IActionResult UpdateRecommendationById(int id, [FromBody] Recommendation rec)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/UpdateRecommendationByIdlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Updating recommendation by id");
                var updateRecommendation = _repo.UpdateRecommendationById(id, rec);
                return Ok(updateRecommendation);
            }
            catch
            {
                Log.Information("failed updating recommendation by id");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
