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
        static Dictionary<string, int> voteData = new Dictionary<string, int>();
        
        // GET: api/Votes
        [HttpGet]
        public IActionResult Get()
        {
            //List<KeyValuePair<string, int>> votes = new List<KeyValuePair<string, int>>(_counts.Count);
            //foreach (KeyValuePair<string, int> kvp in _counts)
            //{
            //    votes.Add(kvp);
            //}
            voteData.Add("Test", 4);
            return Json(voteData);

        }
      
        // PUT: api/Votes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            voteData.Add(value, id);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
