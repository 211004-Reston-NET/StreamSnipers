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
    public class ReviewController : ControllerBase
    {
        private readonly IRepository _repo;

        public ReviewController(IRepository p_repo)
        {
            _repo = p_repo;
        }

        // GET api/review/{id}
        [HttpGet("{id}")]
        public IActionResult GetReviewById(int id)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/GetReviewByIdlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Get Review By ID");
                return Ok(_repo.GetReviewById(id));
            }
            catch
            {
                Log.Information("Failed Get review by ID");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // GET api/review/user/{id}
        [HttpGet("User/{id}")]
        public IActionResult GetReviewByUserId(int id)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/GetReviewByUserIdlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Get review By User Id");
                return Ok(_repo.GetReviewByUserId(id));
            }
            catch
            {
                Log.Information("Failed Get review by User Id");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // Get api/review/imdb/{id}
        [HttpGet("imdb/{id}")]
        public IActionResult GetAllReviewByImdbId(string id)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/GetAllReviewByImdbId.json")
                .CreateLogger();
            try
            {
                Log.Information("Get List of Reviews By ImdbId");
                return Ok(_repo.GetAllReviewByImdbId(id));
            }
            catch
            {
                Log.Information("Failed Get List of Reviews By ImdbId");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // POST api/review/add
        [HttpPost("add")]
        public IActionResult CreateReview([FromBody] Review value)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/CreateReviewlog.json")
                .CreateLogger();
            try 
            {
                Log.Information("Create Review");
                return Created("api/Review/add", _repo.AddReview(value));
            }
            catch
            {
                Log.Information("Failed Create Review");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        //// PUT api/<ReviewController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/review/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteReviewById(int id)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/DeleteReviewByIdlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Delete Review By Id");
                return Ok(_repo.DeleteReviewById(id));
            }
            catch
            {
                Log.Information("Failed Delete Review By Id");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }


        //UPDATE api/update-review-by-id/{id}
        [HttpPut("update-review-by-id/{id}")]
        public IActionResult UpdateReviewById(int id, [FromBody]Review rev)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/UpdateReviewByIdlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Update Review By Id");
                var updateReview = _repo.UpdateReviewById(id, rev);
                return Ok(updateReview);
            }
            catch
            {
                Log.Information("Failed Update Review By Id");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

    }
}
