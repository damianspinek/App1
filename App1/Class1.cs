using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace App1
{
    public class Currency
    {
        public String countryName { get; set; }
        public int conversionRate { get; set; }
        public int currencySymbol { get; set; }
        public String currencyCode { get; set; }
        public double currencyAsPLN { get; set; }

    }
}
