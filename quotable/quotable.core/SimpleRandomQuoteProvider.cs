using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    /// <summary>
    /// Provides up to three randomly selected quotes from the hardcoded list.  
    /// Number of quotes is determined by the value typed into the console.
    /// </summary>
    public class SimpleRandomQuoteProvider : RandomQuoteProvider
    {
        /// <summary>
        /// Retuns an IEnumerable value that contains the randomly selected quotes to be read into the console.
        /// Contains the hardcoded quotes in the string array object test.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public IEnumerable<string> FindQuotes(long val)
        {
            string[] test = new string[3];
            test[0] = "Bad boys for life";
            test[1] = "Live and let die";
            test[2] = "Go hard or go home";
            string[] home;
            if (val <= 3) {
                home = new string[val];
            }
            else { home = new string[3]; }
            for (int i = 0; i < home.Length; i++)
            {
                Random r = new Random();
                home[i] = test[r.Next(0,3)];
            }
            return home;
        }
    }
}
