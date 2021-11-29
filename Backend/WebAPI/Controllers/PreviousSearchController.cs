﻿using Data_Layer;
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
    public class PreviousSearchController : ControllerBase
    {
        private readonly IRepository _repo;
        public PreviousSearchController(IRepository p_repo)
        {
            _repo = p_repo;
        }

        // GET api/<PreviousSearchController>/5
        [HttpGet("{id}")]
        public IActionResult GetPreviousSearchById(int id)
        {
            return Ok(_repo.GetPreviousSearchById(id));
        }

        // GET api/<PreviousSearchController>/User/5
        [HttpGet("User/{id}")]
        public IActionResult GetPreviousSearchByUserId(int id)
        {
            return Ok(_repo.GetPreviousSearchByUserId(id));
        }

        // POST api/<PreviousSearchController>
        [HttpPost("Add")]
        public IActionResult AddPreviousSearch([FromBody] PreviousSearch value)
        {
            return Created("api/PreviousSearch/Add", _repo.AddPreviousSearch(value));
        }

        //// PUT api/<PreviousSearchController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<PreviousSearchController>/5
        [HttpDelete("{id}")]
        public IActionResult DeletePreviousSearchById(int id)
        {
            return Ok(_repo.DeletePreviousSearchById(id));
        }
    }
}