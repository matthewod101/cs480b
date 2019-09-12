using System;
using quotable.core;

namespace quotable.console
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleRandomQuoteProvider s = new SimpleRandomQuoteProvider();
            long N = long.Parse(Console.ReadLine());
            foreach(string i in s.FindQuotes(N))
            {
                Console.WriteLine(i);
            }
            
        }
    }
}
