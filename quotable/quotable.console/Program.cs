using System;
using System.Collections.Generic;
using quotable.core;

namespace quotable.console
{
    /// <summary>
    /// Main class the runs both parts of the program.  
    /// The SimpleRandomQuoteProvider is run first after the long value is typed into the console.
    /// Afterwards, an IEnumerable<string> reads the quotes.txt file, and the DefaultRandomQuoteGenerator
    /// is run.
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            SimpleRandomQuoteProvider s = new SimpleRandomQuoteProvider();
            long N = long.Parse(Console.ReadLine());
            foreach(string i in s.FindQuotes(N))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nThese are the default quotes.");
            IEnumerable<string> lines= System.IO.File.ReadAllLines(@"..\..\quotes.txt");
            DefaultRandomQuoteGenerator d = new DefaultRandomQuoteGenerator(lines);
            N = long.Parse(Console.ReadLine());
            foreach (string i in d.FindQuotes(N))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("End of Program");
        }
    }
}
