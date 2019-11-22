using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotable.core;
using Document = quotable.api.Models.QuotableData;

namespace quotable.api.Controllers
{
    /// <summary>
    /// API controller for the '/quote' resource.
    /// </summary>
    [Route("api/quote")]
    [ApiController]
    public class DBQuotesController : ControllerBase
    {
        private readonly QuotableContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">The database context to data access.</param>
        public DBQuotesController(QuotableContext context)
        {
            _context = context;
        }

        // GET api/values
        /// <summary>
        /// Returns all the quotes.
        /// </summary>
        /// <returns>All the quotes.</returns>
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return from Quote in _context.quotes
                   select new Quote()
                   {
                       quote = Quote.quote
                   };
        }

        // GET api/values/5
        /// <summary>
        /// Gets a specific quote.
        /// </summary>
        /// <param name="id">The id of the quote to get.</param>
        /// <returns>The quote.</returns>
        [HttpGet("{id}")]
        public ActionResult<Document> Get(long id)
        {
            var quote = _context.quotes.SingleOrDefault(q => q.id == id);

            if (quote == null)
            {
                return NotFound();
            }

            return new Document()
            {
                quote = quote.quote
            };
        }
    }
}