namespace ShowDataFromRelatedTables
{
    using System;

    using AdsDB;

    public class AdsInformationUI
    {
        static AdsEntities context = new AdsEntities();
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("Selecting all ads and printing their title, status, category, town and user.");
            Console.Write(decorationLine);

            // Without '.Include()' -> 63 SQL statements executed
            Console.WriteLine("--- Get ads slow version ---");
            var advertisements = context.Ads;

            foreach (var advertisement in advertisements)
            {
                Console.WriteLine("Title: {0}, Status: {1}, Category {2}, Town: {3}, User: {4}.",
                       advertisement.Title,
                       advertisement.AdStatus.Status,
                       advertisement.CategoryId == null ? "(no category)" : advertisement.Category.Name,
                       advertisement.TownId == null ? "(no town)" : advertisement.Town.Name,
                       advertisement.AspNetUser.Name);
            }

            //// With '.Include()' -> 1 SQL statement executed
            //Console.Write(decorationLine);
            //Console.Write(decorationLine);
            //Console.WriteLine("--- Get ads slow version ---");

            //var ads = context.Ads.Include("AdStatus").Include("Category").Include("Town");

            //foreach (var advertisement in ads)
            //{
            //    Console.WriteLine("Title: {0}, Status: {1}, Category {2}, Town: {3}, User: {4}.",
            //           advertisement.Title,
            //           advertisement.AdStatus.Status,
            //           advertisement.CategoryId == null ? "(no category)" : advertisement.Category.Name,
            //           advertisement.TownId == null ? "(no town)" : advertisement.Town.Name,
            //           advertisement.AspNetUser.Name);
            //}
        }
    }
}
