using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotable.core;
using quotable.api.Models;
//Resources found here.
namespace quotable.api.Controllers
{
    /// <summary>
    /// Api controllers that allows the methods to be called through .NET core.
    /// Includes the random quote provider that gives a single random quote.
    /// </summary>
    [Route("api/random")]
    [ApiController]
    public class RandomQuotesController : ControllerBase
    {
        private DefaultRandomQuoteGenerator generator { get; }

        public RandomQuotesController(DefaultRandomQuoteGenerator gen)
        {
            generator = gen;
        }

        /// <summary>
        /// Returns a single randomly selected quote and the author of the quote.
        /// </summary>
        /// <returns>Randomly selected quote and the quotes author.</returns>
        // GET api/values
        [HttpGet]
        public ActionResult<QuotableData> Get()
        {
            var data = new QuotableData();
            Random r = new Random();
            var count = r.Next(0, 101);
            data.id = count;
            data.quote = generator.FindQuoteById(count);
            data.author = generator.FindAuthorById(count);
            return data;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
