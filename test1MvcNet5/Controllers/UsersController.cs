using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using test1MvcNet5.Data.DataModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test1MvcNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IMongoCollection<Users> _users;

        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<List<Users>> Get()
        {
            var client = new MongoClient("mongodb+srv://actek:lzyjgJb5Q8qFUYe1@cluster0.l2v9e.mongodb.net/sample_training?retryWrites=true&w=majority");
            var database = client.GetDatabase("sample_mflix");

            _users = database.GetCollection<Users>("users");

            List<Users> users;
            users = _users.Find(emp => true).ToList();

            return users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
