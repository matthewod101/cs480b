using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quotable.api.Models
{
    /// <summary>
    /// Creates model for grabbing quotes from the list.  
    /// Includes id, quote, and author of quote.
    /// </summary>
    public class QuotableData
    {
        /// <summary>
        /// Gets and sets the id of the quote in the data object
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// Gets and sets the quote in the data object
        /// </summary>
        public string quote { get; set; }
        /// <summary>
        /// Gets and sets the author of the quote in the data object
        /// </summary>
        public string author { get; set; }
    }
}
