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
            return Ok(_repo.GetReviewById(id));
        }

        // GET api/review/user/{id}
        [HttpGet("User/{id}")]
        public IActionResult GetReviewByUserId(int id)
        {
            return Ok(_repo.GetReviewByUserId(id));
        }

        // POST api/review/add
        [HttpPost("Add")]
        public IActionResult CreateReview([FromBody] Review value)
        {
            return Created("api/Review/Add", _repo.AddReview(value));
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
            return Ok(_repo.DeleteReviewById(id));
        }
    }
}
