﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace quotable.core
{
    /// <summary>
    /// Class that selects a single random quote from a passed in IEnumerable.
    /// </summary>
    public class DefaultRandomQuoteGenerator : RandomQuoteProvider
    {
        readonly List<string> lines = new List<string>();
        private readonly IEnumerable<string> s;
        /// <summary>
        /// Receives an IEnumerable value containing a list of quotes
        /// </summary>
        /// <param name="s">IEnumerable that contains a collection of quotes.</param>
        public DefaultRandomQuoteGenerator(IEnumerable<string> s)
        {
            this.s = s;
            foreach (string l in this.s)
            {
                lines.Add(l);
            }
        }

        /// <summary>
        /// Implements the RandomQuoteProvider interface.   Takes the list of quotes and passes it into the lines List object.
        /// The class then selects random quotes and prints it onto the console.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public IEnumerable<string> FindQuotes(long val)
        {
            string[] home;
            if (val <= lines.Count)
            {
                home = new string[val];
            }
            else { home = new string[lines.Count]; }
            for (int i = 0; i < home.Length; i++)
            {
                Random r = new Random();
                home[i] = lines[r.Next(0, lines.Count)];
            }
            return home;
        }

        /// <summary>
        /// Takes an id parameter to determine which quote in the list should be pulled.
        /// </summary>
        /// <param name="id">Determines which quote should be provided</param>
        /// <returns>Desired quote</returns>
        public string FindQuoteById(int id)
        {
            string quote = "";
            int squigly = lines[id].IndexOf("~");
            quote = lines[id].Substring(0, squigly-1);
            return quote;
        }

        /// <summary>
        /// Takes an id parameter to determine which author in the list is pulled from the quote.
        /// </summary>
        /// <param name="id">Id of the author of the quote</param>
        /// <returns>Desired author of the quote.</returns>
        public string FindAuthorById(int id)
        {
            string author = "";
            int squigly = lines[id].IndexOf("~");
            author = lines[id].Substring(squigly+1);
            return author;
        }

        /// <summary>
        /// Determines the first name of the author.
        /// </summary>
        /// <param name="id">Selected id of the author</param>
        /// <returns></returns>
        public string FindAuthorFirstName(int id)
        {
            string authorFName = "";
            string temp = FindAuthorById(id);
            int space = temp.IndexOf(" ");
            authorFName = temp.Substring(0, space+1);
            return authorFName;
        }

        /// <summary>
        /// Determines the first name of the author.
        /// </summary>
        /// <param name="id">Selected id of the author</param>
        /// <returns></returns>
        public string FindAuthorLastName(int id)
        {
            string authorLName = "";
            string temp = FindAuthorById(id);
            int space = temp.LastIndexOf(" ");
            authorLName = temp.Substring(space + 1);
            return authorLName;
        }



        /// <summary>
        /// Getter for the list of quotes for the generator.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> getLines()
        {
            return lines;
        }
    }
}
