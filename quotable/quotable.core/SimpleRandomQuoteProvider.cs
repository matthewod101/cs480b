using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    public class SimpleRandomQuoteProvider : RandomQuoteProvider
    {
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
