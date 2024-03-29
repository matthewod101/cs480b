﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core.tests
{
    class QuotableCoreTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFindQuotesById()
        {
            IEnumerable<string> lines = System.IO.File.ReadAllLines(@"..\..\quotes.txt");
            DefaultRandomQuoteGenerator d = new DefaultRandomQuoteGenerator(lines);
            var id = 5;
            string q = d.FindQuoteById(5);
            string a = d.FindAuthorById(5);
            Assert.That(id, Is.EqualTo(5));
            Assert.That(q, Is.EqualTo("You miss 100% of the shots you don’t take."));
            Assert.That(a, Is.EqualTo("Wayne Gretzky"));
        }
    }
}
