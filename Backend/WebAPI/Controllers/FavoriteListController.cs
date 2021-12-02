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
             Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/allfavoritelistlog.json")
                .CreateLogger();

            try 
            {
                Log.Information("Favorite List acquired");
                return Ok(_repo.GetAllFavoriteList());
            }
            catch
            {
                Log.Information("Failed getting all favorite list");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        // GET api/favoriteList/{id}
        [HttpGet("{id}")]
        public IActionResult GetFavoriteListById(int id)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/favoritelistbyidlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Favorite List by id acquired");
                return Ok(_repo.GetFavoriteListById(id));
            }
            catch
            {
                Log.Information("Failed getting all favorite list by id");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // GET api/favoriteList/user/{id}
        [HttpGet("User/{id}")]
        public IActionResult GetFavoriteListByUserId(int id)
        {
             Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/favoritelistbyuseridlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Favorite List by user Id acquired");
                return Ok(_repo.GetFavoriteListByUserId(id));
            }
            catch
            {
                Log.Information("Failed getting favorite list by id");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // POST api/favoriteList/add
        [HttpPost("Add")]
        public IActionResult AddFavoriteList([FromBody] FavoriteList value)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/addfavoritelistlog.json")
                .CreateLogger();
            try
            {
                Log.Information("Success adding favorite list");
                return Created("api/FavoriteList/Add", _repo.AddFavoriteList(value));
            }
            catch
            {
                Log.Information("Failed adding favorite list");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
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
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/deletefavoritelistlog.json")
                .CreateLogger();
            try
            {
                Log.Information("");
                return Ok(_repo.DeleteFavoriteListById(id));
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


        //UPDATE api/update-favoritelist-by-id/{id}
        [HttpPut("update-favoritelist-by-id/{id}")]
        public IActionResult UpdateFavoriteListById(int id, [FromBody] FavoriteList fList)
        {
             Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/updatefavoritelistlog.json")
                .CreateLogger();
            try
            {
                Log.Information("");
                var updateFavoriteList = _repo.UpdateFavoriteListById(id, fList);
                return Ok(updateFavoriteList);
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
    }
}
