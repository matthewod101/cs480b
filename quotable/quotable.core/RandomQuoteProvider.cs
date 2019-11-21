using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    /// <summary>
    /// Interface for all future implementations of the Random quote providers.
    /// </summary>
    public interface RandomQuoteProvider
    {
        /// <summary>
        /// Interface method for any future quoteproviders to implement.
        /// </summary>
        /// <param name="val">Which quote is to be selected</param>
        /// <returns></returns>
        IEnumerable<string> FindQuotes(long val);
    }
}
