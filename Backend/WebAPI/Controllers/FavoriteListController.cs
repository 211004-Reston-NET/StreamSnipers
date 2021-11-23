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

        // GET: api/<FavoriteListController>
        [HttpGet("All")]
        public IActionResult GetAllFavoriteList()
        {
            return Ok(_repo.GetAllFavoriteList());
        }

        // GET api/<FavoriteListController>/5
        [HttpGet("{id}")]
        public IActionResult GetFavoriteListById(int id)
        {
            return Ok(_repo.GetFavoriteListById(id));
        }

        // GET api/<FavoriteListController>/User/5
        [HttpGet("User/{id}")]
        public IActionResult GetFavoriteListByUserId(int id)
        {
            return Ok(_repo.GetFavoriteListByUserId(id));
        }

        // POST api/<FavoriteListController>
        [HttpPost("Add")]
        public IActionResult AddFavoriteList([FromBody] FavoriteList value)
        {
            return Created("api/FavoriteList/Add", _repo.AddFavoriteList(value));
        }

        //// PUT api/<FavoriteListController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<FavoriteListController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteFavoriteListById(int id)
        {
            return Ok(_repo.DeleteFavoriteListById(id));
        }
    }
}
