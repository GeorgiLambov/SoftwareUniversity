using System;
class LaptopShop
{
    static void Main()
    {
        Battery batt = new Battery("6-cell", 4.27);
        Laptop laptop = new Laptop("Dell Inspiron 3537", (decimal)978.00, "Dell", batt, "Intel Core i5-4200U", "8GB DDR 3 1600", "AMD Radeon HD 8670M", "500GB HDD", "15.6 inch");

        Console.WriteLine(laptop);

        laptop = new Laptop("Acer E255", 1200m);
        Console.WriteLine(laptop);
     
        laptop = new Laptop("Lenovo 344A", 1444.23m, "Lenovo", battery: batt, screen: "17.0 inch");
        Console.WriteLine(laptop);
        
    }
}

