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
        IEnumerable<string> FindQuotes(long val);
    }
}
