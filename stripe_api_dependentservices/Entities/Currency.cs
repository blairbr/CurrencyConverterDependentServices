using System;
using System.Collections.Generic;

namespace stripe_api_dependentservices.Entities
{
    public class Currency
    {
        public string Base_code { get; set; }

        public Dictionary<string, string> Conversion_rates { get; set; }

        public double ConvertedValue { get; set; }

    }
}
