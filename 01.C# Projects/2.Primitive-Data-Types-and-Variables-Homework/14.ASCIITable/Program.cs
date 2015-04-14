using System;
using System.Text;
class ASCIITable
{
    static void Main()
    {
        Console.WriteLine("The full ASCII Table:");
            
        {
            for (int table = 0; table < 256; table++)
            {
                Console.OutputEncoding = Encoding.ASCII;
                Console.WriteLine("Character: {0} = {1}", table, (char)table);
            }
        }
    }
}
