using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace quotable.core
{
    /// <summary>
    /// Class that selects a single random quote from a passed in IEnumerable<string>.
    /// </summary>
    public class DefaultRandomQuoteGenerator : RandomQuoteProvider
    {
        private IEnumerable<string> s;
        /// <summary>
        /// Receives an IEnumerable<string> value containing a list of quotes
        /// </summary>
        /// <param name="s">IEnumerable<string> that contains a collection of quotes.</param>
        public DefaultRandomQuoteGenerator(IEnumerable<string> s)
        {
            this.s = s;
            
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
            List<string> lines = new List<string>();
            foreach (string l in s)
            {
                lines.Add(l);
            }
            if (val <= lines.Count)
            {
                home = new string[val];
            }
            else { home = new string[3]; }
            for (int i = 0; i < home.Length; i++)
            {
                Random r = new Random();
                home[i] = lines[r.Next(0, lines.Count)];
            }
            return home;
        }
    }
}
