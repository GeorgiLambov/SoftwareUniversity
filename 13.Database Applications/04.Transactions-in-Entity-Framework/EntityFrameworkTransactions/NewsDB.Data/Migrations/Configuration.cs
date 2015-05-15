namespace NewsDB.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using NewsDB.Model;

    public sealed class Configuration :
        DbMigrationsConfiguration<NewsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NewsDbContext context)
        {
            var news = new List<News>
              {
                  new News()
                  {
                      Content = "Зарядни за мобилни устройства в парковете"
                  },
                  new News()
                  {
                      Content = "Visual Studio 2013 и инициализиране на масив"
                  },
                      new News()
                  {
                      Content = "[Homework] Programming Basics - Console Input Output - Problem {3} - Circle Perimeter And Area"
                  },
                  new News()
                  {
                      Content = "Вариант за създаване на абстрактен метод в JavaScript?"
                  },    new News()
                  {
                      Content = "C# basics alpha срок за плащане."
                  },
                  new News()
                  {
                      Content = "Относно Какво може да ползваме на изпита ?"
                  }
              };

            news.ForEach(c => context.News.AddOrUpdate(n => n.Content, c));

            context.SaveChanges();
        }
    }
}
