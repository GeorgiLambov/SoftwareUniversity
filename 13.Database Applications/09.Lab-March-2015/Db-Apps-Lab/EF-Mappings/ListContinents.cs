namespace EF_Mappings
{
    using System;

    class ListContinents
    {
        static void Main()
        {
            var context = new GeographyEntities();
            foreach (var continent in context.Continents)
            {
                Console.WriteLine(continent.ContinentName);
            }
        }
    }
}
