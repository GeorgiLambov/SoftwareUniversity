namespace PlayWithToList
{
    using System;
    using System.Linq;

    using AdsDB;

    public class PlayWithToList
    {
        static AdsEntities context = new AdsEntities();

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Getting information about the advertisements by Staus***");
            Console.Write(decorationLine);

            //// With '.ToList()' many times 
            //var adsWithSlowQwery = context.Ads
            //    .ToList()
            //    .Where(ad => ad.AdStatus.Status == "Published")
            //    .OrderBy(ad => ad.Date)
            //    .ToList()
            //    .Select(ad =>
            //        new
            //        {
            //            Title = ad.Title,
            //            Category = ad.Category,
            //            Town = ad.Town
            //        })
            //    .ToList();

            // Console.WriteLine("The Ads with status 'Published' are: {0}", adsWithSlowQwery.Count());

            // Without '.ToList()' -> 1 SQL statement executed
            var adsWithOptimizedQwery = context.Ads
             .Where(ad => ad.AdStatus.Status == "Published")
             .OrderBy(ad => ad.Date)
             .Select(ad =>
                 new
                 {
                     Title = ad.Title,
                     Status = ad.AdStatus.Status,
                     Category = ad.Category,
                     Town = ad.Town
                 })
             .ToList();

            foreach (var ads in adsWithOptimizedQwery)
            {
                Console.WriteLine("Ads Title: {0}, Status: {1}, Category: {2}, Town: {3}, ",
                    ads.Title,
                    ads.Status,
                    ads.Category == null ? "(no category)" : ads.Category.Name,
                    ads.Town == null ? "(no town)" : ads.Town.Name);
            }
        }
    }
}
