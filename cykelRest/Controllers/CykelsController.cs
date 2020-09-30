using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cykelLib.model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cykelRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CykelsController : ControllerBase
    {
        private static List<Cykel> _data = new List<Cykel>()
        {
            new Cykel(1, "rød", 1500, 7),
            new Cykel(2, "gul", 1300, 3),
            new Cykel(3, "blå", 1700, 5),
            new Cykel(4, "sort", 2400, 10),
            new Cykel(5, "brun", 2900, 21)
        };

        // GET: api/<CykelsController>
        [HttpGet]
        public IEnumerable<Cykel> Get()
        {
            return _data;
        }

        // GET api/<CykelsController>/5
        [HttpGet("{id}")]
        public Cykel Get(int id)
        {
            return _data.Find(c => c.Id == id);
        }

        // POST api/<CykelsController>
        [HttpPost]
        public void Post([FromBody] Cykel value)
        {
            _data.Add(value);
        }

        // PUT api/<CykelsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cykel value)
        {
            Cykel cykel = Get(id);
            if (cykel != null)
            {
                cykel.Id = value.Id;
                cykel.Farve = value.Farve;
                cykel.Pris = value.Pris;
                cykel.Gear = value.Gear;
            }
        }

        // DELETE api/<CykelsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Cykel cykel = Get(id);
            if (cykel != null)
            {
                _data.Remove(cykel);
            }
        }
    }
}
