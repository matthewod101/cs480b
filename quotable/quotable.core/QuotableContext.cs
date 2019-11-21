using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    /// <summary>
    /// The context of the database that will allow access to quotes and their authors
    /// </summary>
    public class QuotableContext : DbContext
    {
        /// <summary>
		/// Constructor
		/// </summary>
		public QuotableContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Used to access quotes in the database.
        /// </summary>
        public DbSet<Quote> quotes { get; set; }

        /// <summary>
        /// Used to access authors in the database.
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <inheritquote/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuoteAuthor>().HasKey(x => new { x.QuoteId, x.AuthorId });
        }
    }
}
