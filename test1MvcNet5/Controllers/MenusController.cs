using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test1MvcNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        // GET: api/<PlatillosController>
        [Authorize]
        [HttpGet]
        public IEnumerable<DataModel.Menu> Get()
        {
            using (var db = new DataModel.MiRestauranteContext())
            {
                IEnumerable<DataModel.Menu> menus = db.Menus.ToList();
                return menus;
            }
        }

        // GET api/<PlatillosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PlatillosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PlatillosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlatillosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
