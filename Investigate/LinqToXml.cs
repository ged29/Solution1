using System;
using System.Linq;
using System.Xml.Linq;

namespace Investigate
{
    public class LinqToXml
    {
        public static void Main()
        {
            XDocument doc = XDocument.Load("data.xml");
            var filtered = from p in doc.Descendants("Product")
                           join s in doc.Descendants("Supplier")
                           on (int)p.Attribute("SupplierID") equals (int)s.Attribute("SupplierID")
                           where (decimal)p.Attribute("Price") > 10
                           orderby (string)p.Attribute("Name"), (string)s.Attribute("Name")
                           select new
                           {
                               SupplierName = (string)s.Attribute("Name"),
                               ProductName = (string)p.Attribute("Name")
                           };

            foreach (var v in filtered)
            {
                Console.WriteLine("Supplier={0}; Product={1}", v.SupplierName, v.ProductName);
            }
        }
    }
}
