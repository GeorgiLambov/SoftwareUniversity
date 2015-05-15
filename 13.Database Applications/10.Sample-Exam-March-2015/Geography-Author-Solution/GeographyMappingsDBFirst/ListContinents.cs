using System;

using GeographyMappingsDBFirst;

class ListContinents
{
    static void Main()
    {
        Console.WriteLine("Continents:");
        var context = new GeographyEntities();
        foreach (var continent in context.Continents)
        {
            Console.WriteLine(continent.ContinentName);
        }
    }
}
