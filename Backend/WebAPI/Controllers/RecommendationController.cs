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
            return Ok(_repo.GetRecommendationById(id));
        }

        // GET api/recommendation/user/{id}
        [HttpGet("User/{id}")]
        public IActionResult GetRecommendationByUserId(int id)
        {
            return Ok(_repo.GetRecommendationByUserId(id));
        }

        // POST api/recommendation/add
        [HttpPost("Add")]
        public IActionResult AddRecommendation([FromBody] Recommendation value)
        {
            return Created("api/Recommendation/Add", _repo.AddRecommendation(value));
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
            return Ok(_repo.DeleteRecommendationById(id));
        }
    }
}
