using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace App1
{
    class CurrencyPArser
    {

        private static String url = "http://www.nbp.pl/kursy/xml/a001z020102.xml";

        public static async void downloadXml()
        {
            HttpClient httpClient = new HttpClient();
            String fileContent = await httpClient.GetStringAsync(url);

            //System.Diagnostics.Debug.Write(fileContent);

            XDocument xdoc = new XDocument();

            xdoc = XDocument.Parse(fileContent);

            var result = from elem in xdoc.Descendants("pozycja")
                         select new Currency
                         {
                             countryName = (String)elem.Element("nazwa_kraju"),
                             conversionRate = Int16.Parse((String)elem.Element("przelicznik")),
                             currencyAsPLN = Double.Parse((String)elem.Element("kurs_sredni")),
                             currencyCode = (String)elem.Element("kod_waluty"),
                             currencySymbol = Int16.Parse((String)elem.Element("symbol_waluty"))
                         };

            foreach (var record in result)
            {
                System.Diagnostics.Debug.WriteLine("Country: " + record.countryName + " Conversion rate: " + record.conversionRate +
                    " as PLN " + record.currencyAsPLN + " Currency code " + record.currencyCode + " Currency symbol " + record.currencySymbol);
            }


        }
    }
}
