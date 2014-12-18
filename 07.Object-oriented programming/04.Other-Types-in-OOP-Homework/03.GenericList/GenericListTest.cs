using System;

class GenericListTest
{
    static void Main()
    {
        var intList = new GenericList<int>();

        intList.Add(1);
        intList.Add(2);
        intList.Add(3);
        intList.Add(4);
        intList.Add(5);
        Console.WriteLine("Number of elements: {0}", intList.Count);
        Console.WriteLine(intList);
        intList[4] = 133;
        Console.WriteLine(intList);

        intList.Remove(2);
        Console.WriteLine(intList);

        intList.Insert(0, 4);
        Console.WriteLine(intList);

        Console.WriteLine(intList.Find(133));

        Console.WriteLine(intList.Contains(4));

        Console.WriteLine("Max = " + intList.Max());
        Console.WriteLine("Min = " + intList.Min());

        intList.Clear();
        Console.WriteLine("Elemets in List: " + intList.Count);

        Type type = typeof(GenericList<>);
        object[] allAttributes = type.GetCustomAttributes(typeof(VersionAttribute), false);
        Console.WriteLine("GenericsList's version is {0}", ((VersionAttribute)allAttributes[0]).Version);
    }
}

