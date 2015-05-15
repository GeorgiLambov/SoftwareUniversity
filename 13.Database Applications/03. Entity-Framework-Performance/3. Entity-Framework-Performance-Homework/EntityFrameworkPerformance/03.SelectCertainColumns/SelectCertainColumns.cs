namespace SelectCertainColumns
{
    using System;

    using System.Linq;
    using AdsDB;

    public class SelectCertainColumns
    {
        static AdsEntities context = new AdsEntities();

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Select Everything vs. Select Certain Columns***");
            Console.Write(decorationLine);

            var ads = context.Ads.ToList();
            foreach (var ad in ads)
            {
                Console.WriteLine("Ads Title: {0}", ad.Title);
            }

            //var adsTitle = context.Ads.Select(a => a.Title);
            //foreach (var title in adsTitle)
            //{
            //    Console.WriteLine("Title: {0}", title);
            //}
        }
    }
}
