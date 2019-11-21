using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    /// <summary>
    /// Model for the author of the quote
    /// </summary>
    public sealed class Author
    {
        /// <summary>
        /// Id of the author
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// Author's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Author's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Established relation between author and quote
        /// </summary>
        public ICollection<QuoteAuthor> QuoteAuthor { get; set; }
    }
}
