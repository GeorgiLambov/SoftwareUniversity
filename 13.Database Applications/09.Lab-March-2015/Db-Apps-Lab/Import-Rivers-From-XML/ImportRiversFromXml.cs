namespace Import_Rivers_From_XML
{
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using EF_Mappings;

    public class ImportRiversFromXml
    {
        static void Main()
        {
            var context = new GeographyEntities();
            // var rivers = context.Rivers.Count(); // check DB

            // Load the XML from file and test print
            var xmlDoc = XDocument.Load(@"..\..\rivers.xml");
            //System.Console.WriteLine(xmlDoc);

            var riverNodes = xmlDoc.XPathSelectElements("/rivers/river");
            foreach (var riverNode in riverNodes)
            {
                //extract the mandatory fields 
                string riverName = riverNode.Element("name").Value;
                int riverLenght = int.Parse(riverNode.Element("length").Value);
                string riverOutflow = riverNode.Element("outflow").Value;

                //extract the optional fields
                int? drainageArea = null;
                if (riverNode.Element("drainage-area") != null)
                {
                    drainageArea = int.Parse(riverNode.Element("drainage-area").Value);
                }

                int? averageDischarge = null;
                if (riverNode.Element("average-discharge") != null)
                {
                    averageDischarge = int.Parse(riverNode.Element("average-discharge").Value);
                }

                // Import the parsed rivers into the database
                var river = new River()
                {
                    RiverName = riverName,
                    Length = riverLenght,
                    Outflow = riverOutflow,
                    DrainageArea = drainageArea,
                    AverageDischarge = averageDischarge
                };


                // Load the countries for each river 
                var countryNodes = riverNode.XPathSelectElements("countries/country");
                var countryNames = countryNodes.Select(c => c.Value);
                foreach (var countryName in countryNames)
                {
                    var country = context.Countries.FirstOrDefault(c => c.CountryName == countryName);
                    river.Countries.Add(country);
                }

                // Save the river in the database
                context.Rivers.Add(river);
                context.SaveChanges();
            }

            System.Console.WriteLine("Rivers imported from rivers.xml");
        }
    }
}



//            // Parse the river properties
//            var river = new River
//            {
//                RiverName = riverNode.Descendants("name").First().Value,
//                Length = int.Parse(riverNode.Descendants("length").First().Value),
//                Outflow = riverNode.Descendants("outflow").First().Value
//            };
//            var drainageArea = riverNode.Descendants("drainage-area").FirstOrDefault();
//            if (drainageArea != null)
//            {
//                river.DrainageArea = int.Parse(drainageArea.Value);
//            }
//            var averageDischarge = riverNode.Descendants("average-                     discharge").FirstOrDefault();
//            if (averageDischarge != null)
//            {
//                river.AverageDischarge = int.Parse(averageDischarge.Value);
//            }

//            // Load the countries for each river 
//            var countryNodes = riverNode.XPathSelectElements("countries/country");
//            foreach (var countryNode in countryNodes)
//            {
//                var country = context.Countries.
//                    FirstOrDefault(c => c.CountryName == countryNode.Value);
//                if (country == null)
//                {
//                    throw new Exception("Can not find country: " + countryNode.Value);
//                }
//                river.Countries.Add(country);
//            }

//            // Save the river in the database 
//            context.Rivers.Add(river);
//            context.SaveChanges();