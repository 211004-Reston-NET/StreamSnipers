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
    public class FavoriteListController : ControllerBase
    {
        private readonly IRepository _repo;
        public FavoriteListController(IRepository p_repo)
        {
            _repo = p_repo;
        }

        // GET: api/favoriteList/all
        [HttpGet("All")]
        public IActionResult GetAllFavoriteList()
        {
            return Ok(_repo.GetAllFavoriteList());
        }

        // GET api/favoriteList/{id}
        [HttpGet("{id}")]
        public IActionResult GetFavoriteListById(int id)
        {
            return Ok(_repo.GetFavoriteListById(id));
        }

        // GET api/favoriteList/user/{id}
        [HttpGet("User/{id}")]
        public IActionResult GetFavoriteListByUserId(int id)
        {
            return Ok(_repo.GetFavoriteListByUserId(id));
        }

        // POST api/favoriteList/add
        [HttpPost("Add")]
        public IActionResult AddFavoriteList([FromBody] FavoriteList value)
        {
            return Created("api/FavoriteList/Add", _repo.AddFavoriteList(value));
        }

        //// PUT api/favoriteList/{id}
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/favoriteList/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteFavoriteListById(int id)
        {
            return Ok(_repo.DeleteFavoriteListById(id));
        }
    }
}
