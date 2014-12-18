namespace StringDisperser
{
    using System;
    class TestStringDisperser
    {
        static void Main()
        {
            var stringDisperser = new StringDisperser("gosho", "pesho", "tanio");
            var stringDisperserCopy = (StringDisperser)stringDisperser.Clone();
            stringDisperserCopy.AllString.Append("petko");
            foreach (var ch in stringDisperser)
            {
                Console.Write(ch + " ");
            }

            Console.WriteLine();
            foreach (var ch in stringDisperserCopy)
            {
                Console.Write(ch + " ");
            }
        }
    }
}
