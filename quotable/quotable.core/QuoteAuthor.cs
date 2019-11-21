using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    /// <summary>
    /// Created relation between the quote and its author
    /// </summary>
    public class QuoteAuthor
    {
        /// <summary>
		/// The ID of the quote related to the author.
		/// </summary>
		public long QuoteId { get; set; }
        /// <summary>
        /// The quote related to the author.
        /// </summary>
        public Quote quote { get; set; }

        /// <summary>
        /// The ID of the author related to the quote.
        /// </summary>
        public long AuthorId { get; set; }
        /// <summary>
        /// The author related to the quote.
        /// </summary>
        public Author Author { get; set; }
    }
}
