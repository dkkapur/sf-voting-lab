using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VotingService.Controllers
{
    [Produces("application/json")]
    [Route("api/Votes")]
    public class VotesController : Controller
    {
        // Holds the votes and counts. NOTE: THIS IS NOT THREAD SAFE FOR THE PURPOSES OF THE LAB.
        static Dictionary<string, int> _counts = new Dictionary<string, int>();
        
        // GET: api/Votes
        [HttpGet]
        public IActionResult Get()
        {
            //List<KeyValuePair<string, int>> votes = new List<KeyValuePair<string, int>>(_counts.Count);
            //foreach (KeyValuePair<string, int> kvp in _counts)
            //{
            //    votes.Add(kvp);
            //}
            _counts.Add("Test", 4);
            return Json(_counts);

        }

        // GET: api/Votes/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            _counts.Add("Test2", 4);
            return Json(_counts);
        }
        
        // POST: api/Votes
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Votes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
