using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
class PC_Catalog
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

        Component box = new Component(name: "Box", price: 36.18m, details: "PC DELUX MV871");
        Component mb = new Component(name: "MotherBoard", price: 52.12m);
        Component hdd = new Component(name: "HDD", price: 50.22m);
        Component procesor = new Component(name: "Processor", price: 70.22m, details: "Intel Core Duo T4400 ");
        Component gc = new Component(name: "Graphics Card", price: 170.22m);
        Component ram = new Component(name: "RAM", price: 40.22m, details: "ddr2");

        Computer pc1 = new Computer("PC1", new List<Component>() { box, hdd, gc, ram, mb });
        Computer pc2 = new Computer("PC2", new List<Component>() { box, mb, hdd, procesor, gc, ram });
        Computer pc3 = new Computer("PC3", new List<Component>() { box, mb, hdd, procesor, gc });


        List<Computer> computers = new List<Computer>() { pc1, pc2, pc3 };
        computers.OrderBy(computer => computer.Price).ToList().ForEach(computer => Console.WriteLine(computer.ToString()));

    }
}

