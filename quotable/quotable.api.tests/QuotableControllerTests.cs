using quotable.core;
using quotable.api.Models;
using quotable.api.Controllers;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IEnumerable<string> lines = System.IO.File.ReadAllLines(@"..\..\quotes.txt");
            DefaultRandomQuoteGenerator d = new DefaultRandomQuoteGenerator(lines);
            QuotesController q = new QuotesController(d);

            var actual1 = q.Get(5);

            Assert.That(actual1.Value.id, Is.EqualTo(5));
            Assert.That(actual1.Value.quote, Is.EqualTo("You miss 100% of the shots you don’t take."));
            Assert.That(actual1.Value.author, Is.EqualTo("Wayne Gretzky"));

        }
    }
}