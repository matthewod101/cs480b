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
        /// Abstract method for all future quoteproviders
        /// </summary>
        /// <param name="val">Id of quote</param>
        /// <returns></returns>
        IEnumerable<string> FindQuotes(long val);
    }
}
