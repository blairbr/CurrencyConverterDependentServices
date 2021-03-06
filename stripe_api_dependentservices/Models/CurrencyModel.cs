﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stripe_api_dependentservices.Models
{
    public class CurrencyModel
    {
        public decimal AmountToBeConverted { get; set; }
        public string CodeAndRate { get; set; }
        public string TargetCurrencyCode { get; set; }
        public decimal ConversionRate { get; set; }
        public decimal FinalAmountInTargetCurrency { get; set; }

    }
}
