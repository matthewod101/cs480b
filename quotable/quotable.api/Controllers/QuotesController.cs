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
    [Route("api/quotes")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private DefaultRandomQuoteGenerator generator { get; }

        public QuotesController(DefaultRandomQuoteGenerator gen)
        {
            generator = gen;
        }

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
