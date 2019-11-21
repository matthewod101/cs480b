using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace quotable.core
{
    /// <summary>
    /// Model of the quote object
    /// </summary>
    public sealed class Quote
    {
        /// <summary>
        /// Id of the quote
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// The quote
        /// </summary>
        public string quote { get; set; }

        /// <summary>
        /// The list of authors.
        /// </summary>
        public IEnumerable<Author> Authors => from x in QuoteAuthor select x.Author;

        /// <summary>
        /// Established relation between author and quote
        /// </summary>
        public ICollection<QuoteAuthor> QuoteAuthor { get; set; }
    }
}
