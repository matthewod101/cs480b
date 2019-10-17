using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quotable.api.Models
{
    public class QuotableData
    {
        public long id { get; set; }
        public string quote { get; set; }
        public string author { get; set; }

    }
}
