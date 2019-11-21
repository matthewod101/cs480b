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
    /// Includes the quote provider from a given Id and the provider of the entire list of quotes.
    /// </summary>
    [Route("api/quotes")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private DefaultRandomQuoteGenerator generator { get; }

        /// <summary>
        /// Constructor for the controller object.
        /// </summary>
        /// <param name="gen"></param>
        public QuotesController(DefaultRandomQuoteGenerator gen)
        {
            generator = gen;
        }

        /// <summary>
        /// .Net GET for the entire list of quotes.
        /// </summary>
        /// <returns>List of all the quotes.</returns>
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<QuotableData>> Get()
        {
            QuotableData[] results = new QuotableData[101];
            var count = 0;
            foreach(string l in generator.getLines())
            {
                var data = new QuotableData();
                data.id = count;
                data.quote = generator.FindQuoteById(count);
                data.author = generator.FindAuthorById(count);
                results[count] = data;
                count++;
            }
            return results;
        }

        /// <summary>
        /// .net Get for a single quote determined by the given Id.
        /// </summary>
        /// <param name="id">Given Id that selects the quote being searched for.</param>
        /// <returns>Quote and author of the quote of the given Id.</returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<QuotableData> Get(int id)
        {
            var data = new QuotableData();
            data.id = id;
            data.quote = generator.FindQuoteById(id);
            data.author = generator.FindAuthorById(id);
            return data;
        }

        // POST api/values
        /// <summary>
        /// Unimplemented Post method
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// Unimplemented Put method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// Unimplemented Delete method
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
