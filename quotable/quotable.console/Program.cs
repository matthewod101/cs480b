using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using quotable.core;


namespace quotable.console
{
    /// <summary>
    /// Homework three Creates a database with all of the quotes and respective authors that allows them to be retrieved.
    /// </summary>
    public class Program
    {
        private static async Task Main(string[] args)
        {
            var c = new ServiceCollection();
            c.AddDbContext<QuotableContext>(options => options.UseSqlite("Data Source=quotes.db"), ServiceLifetime.Transient);
            var provider = c.BuildServiceProvider();
            using (var context = provider.GetService<QuotableContext>())
            {
                await context.Database.EnsureDeletedAsync();
                var dbNE = await context.Database.EnsureCreatedAsync();
                if(dbNE)
                {
                    await PopulateDatabase(context);
                }
            }

            using (var context = provider.GetService<QuotableContext>())
            {
                var quotes = context.quotes
                                        .Include(d => d.QuoteAuthor)
                                        .ThenInclude(x => x.Author);

                foreach (var quote in quotes)
                {
                    Console.WriteLine($"Quote.id = {quote.id}");
                    Console.WriteLine($"Quote.title = {quote.quote}");

                    foreach (var author in quote.Authors)
                    {
                        Console.WriteLine($"Quote.author.id = {author.id}");
                        Console.WriteLine($"Quote.author.firstname = {author.FirstName}");
                        Console.WriteLine($"Quote.author.firstname = {author.LastName}");
                    }

                    Console.WriteLine();
                }
            }

            Console.ReadKey();

        }

        /// <summary>
        /// Main class the runs both parts of the program.  
        /// The SimpleRandomQuoteProvider is run first after the long value is typed into the console.
        /// Afterwards, an IEnumerable reads the quotes.txt file, and the DefaultRandomQuoteGenerator is run.
        /// </summary>
        private static async Task PopulateDatabase(QuotableContext c)
        {
            IEnumerable<string> lines = System.IO.File.ReadAllLines(@"..\..\quotes.txt");
            DefaultRandomQuoteGenerator d = new DefaultRandomQuoteGenerator(lines);
            var count = 0;
            foreach (string s in lines)
            {
                var author = new Author()
                {
                    FirstName = d.FindAuthorFirstName(count),
                    LastName = d.FindAuthorLastName(count)
                };
                var quote = new Quote();
                quote.quote = d.FindQuoteById(count);
                var qa = new QuoteAuthor() { quote = quote, Author = author };
                c.AddRange(qa);
                count++;
            }
            await c.SaveChangesAsync();
        }

        private void HW2 ()
        {
            SimpleRandomQuoteProvider s = new SimpleRandomQuoteProvider();
            long N = long.Parse(Console.ReadLine());
            foreach (string i in s.FindQuotes(N))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nThese are the default quotes.");
            IEnumerable<string> lines = System.IO.File.ReadAllLines(@"..\..\quotes.txt");
            DefaultRandomQuoteGenerator d = new DefaultRandomQuoteGenerator(lines);
            N = long.Parse(Console.ReadLine());
            foreach (string i in d.FindQuotes(N))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("End of Program HW1-2");
        }
    }
}
