using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stripe_api_dependentservices.Entities
{
    public class Currency
    {
        public string Base_code { get; set; }

        public Dictionary<string, string> Conversion_rates { get; set; }
    }
}
