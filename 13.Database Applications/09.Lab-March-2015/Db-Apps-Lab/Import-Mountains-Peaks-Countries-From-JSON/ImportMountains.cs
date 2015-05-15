namespace Import_Mountains_From_JSON
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using Mountains_Code_First;

    class ImportMountains
    {
        static void Main()
        {

            var json = File.ReadAllText(@"..\..\mountains.json");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var mountains = serializer.Deserialize<MountainDTO[]>(json);

            foreach (var mountainDTO in mountains)
            {
                try
                {
                    ImportMountain(mountainDTO);
                    Console.WriteLine("Mountain {0} imported", mountainDTO.MountainName);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error: {0} ", ex.Message);
                }
            }
        }

        private static void ImportMountain(MountainDTO mountainDTO)
        {
            var context = new MountainsContext();

            // Parse mountain
            if (mountainDTO.MountainName == null)
            {
                throw new Exception("Missing mountain name");
            }
            var mountainToImport = new Mountain { Name = mountainDTO.MountainName };

            // Parse peaks optional
            foreach (var peakDto in mountainDTO.Peaks)
            {
                if (peakDto.PeakName == null)
                {
                    throw new Exception("Missing peak name");
                }
                if (peakDto.Elevation == null)
                {
                    throw new Exception("Missing peak elevation");
                }

                mountainToImport.Peaks.Add(new Peak()
                {
                    Name = peakDto.PeakName,
                    Elevation = peakDto.Elevation.GetValueOrDefault()
                });
            }

            // Parse countries optional
            foreach (var countryName in mountainDTO.Countries)
            {
                var country = context.Countries.FirstOrDefault(c => c.Name == countryName);
                if (country == null)
                {
                    country = new Country()
                    {
                        Code = countryName.ToUpper().Substring(0, 2),
                        Name = countryName
                    };
                }

                mountainToImport.Countries.Add(country);
            }

            context.Mountains.Add(mountainToImport);
            context.SaveChanges();
        }
    }
}
