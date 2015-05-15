namespace _02.ConcurrentUpdates_ConsoleApp_
{
    using System;
    using System.Data.Entity;
    using NewsDB.Data.Migrations;

    using NewsDB.Data;
    using NewsDB.Model;

    public class NewsIU
    {
        static NewsDbContext db = new NewsDbContext();

        static void Main()
        {
            // Data Source=.;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDbContext,
                Configuration>());
            db.Database.Initialize(true);

            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Presenting some data from the NewsDB database");
            Console.WriteLine("Created with Code First approach***");
            Console.Write(decorationLine);

            foreach (var news in db.News)
            {
                Console.WriteLine("Id= {0}, Content=  {1}", news.Id, news.Content);
            }

            try
            {
                var text = Console.ReadLine();
                var newValue = new News
                {
                    Content = text
                };

                db.News.Add(newValue);
                db.SaveChanges();
                Console.WriteLine("Changes successfully saved in the DB!!!");
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
