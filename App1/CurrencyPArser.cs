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

        private static String url = "http://www.nbp.pl/kursy/xml/lastA.xml";

        public static async Task<IEnumerable<Currency>> downloadXml()
        {
            HttpClient httpClient = new HttpClient();
            String fileContent = await httpClient.GetStringAsync(url);

            //System.Diagnostics.Debug.Write(fileContent);

            XDocument xdoc = new XDocument();

            xdoc = XDocument.Parse(fileContent);

            var result = from elem in xdoc.Descendants("pozycja")
                         select new Currency
                         {
                             nazwaWaluty = (String)elem.Element("nazwa_kraju"),
                             kursWaluty = Double.Parse((String)elem.Element("kurs_sredni")),
                             kodWaluty = (String)elem.Element("kod_waluty")
                         };

            return result;


        }
    }
}
