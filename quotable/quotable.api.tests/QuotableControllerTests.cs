using quotable.core;
using quotable.api.Models;
using quotable.api.Controllers;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Test cases for all of the api controller gets from both the QuotesController and the RandomQuotesController.
    /// </summary>
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetSingleQuoteFive()
        {
            IEnumerable<string> lines = System.IO.File.ReadAllLines(@"..\..\quotes.txt");
            DefaultRandomQuoteGenerator d = new DefaultRandomQuoteGenerator(lines);
            QuotesController q = new QuotesController(d);

            var actual1 = q.Get(5);

            Assert.That(actual1.Value.id, Is.EqualTo(5));
            Assert.That(actual1.Value.quote, Is.EqualTo("You miss 100% of the shots you don’t take."));
            Assert.That(actual1.Value.author, Is.EqualTo("Wayne Gretzky"));
        }

        [Test]
        public void TestGetAllQuotes()
        {
            IEnumerable<string> lines = System.IO.File.ReadAllLines(@"..\..\quotes.txt");
            DefaultRandomQuoteGenerator d = new DefaultRandomQuoteGenerator(lines);
            QuotesController q = new QuotesController(d);
            var expected = 101;
            var count = 0;
            var actual1 = q.Get();
            var finalCount = 0;
            foreach(QuotableData qd in actual1.Value)
            {
                if(qd.quote == d.FindQuoteById(count) && qd.author==d.FindAuthorById(count))
                {
                    finalCount++;
                }
                count++;
            }
            Assert.AreEqual(finalCount, expected);
        }

        [Test]
        public void TestGetRandomQuote()
        {
            IEnumerable<string> lines = System.IO.File.ReadAllLines(@"..\..\quotes.txt");
            DefaultRandomQuoteGenerator d = new DefaultRandomQuoteGenerator(lines);
            RandomQuotesController q = new RandomQuotesController(d);
            var actual1 = q.Get();
            var finalCount = 0;
            var count = 0;
            foreach(string l in lines)
            {
                if (actual1.Value.quote == d.FindQuoteById(count) && actual1.Value.author == d.FindAuthorById(count))
                {
                    finalCount++;
                }
                count++;
            }
            Assert.AreEqual(finalCount, 1);
        }
    }
}