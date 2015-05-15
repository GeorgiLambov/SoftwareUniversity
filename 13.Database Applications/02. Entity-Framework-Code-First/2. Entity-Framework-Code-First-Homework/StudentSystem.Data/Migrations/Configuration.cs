namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Linq;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;

    using StudentSystem.Model;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );

            //if (context.Students.Any())
            //{
            //    // Seed initial data only if the database is empty
            //    return;
            //}


            SeedCourses(context);
            SeedStudents(context);
            SeedResources(context);
            SeedHomeworkSubmissions(context);


        }
        private void SeedCourses(StudentSystemDbContext context)
        {
            var courses = new List<Course>
            {
                new Course()
                {
                    Name = "C# Basics",
                    Description = "Introduction to C#, .NET Framework, OOP, etc.",
                    StartDate = new DateTime(2014, 3, 4),
                    EndDate = new DateTime(2014, 4, 20),
                    Price = 300
                }, 
                new Course()
                {
                    Name = "C# OOP",
                    Description = "Class modeling, working with inheritance, abstraction, capsulation, interfaces introduction.",
                    StartDate = new DateTime(2014, 6, 1),
                    EndDate = new DateTime(2014, 7, 10),
                    Price = 250
                }, 
                new Course()
                {
                    Name = "Java Basics",
                    Description = "Introduction to programming with Java",
                    StartDate = new DateTime(2014, 7, 12),
                    EndDate = new DateTime(2014, 8, 20),
                    Price = 250
                }, 
                new Course()
                {
                    Name = "HTML & CSS",
                    Description = "Introduction to HTML and CSS, web page design, etc.",
                    StartDate = new DateTime(2014, 8, 23),
                    EndDate = new DateTime(2014, 9, 25),
                    Price = 200
                }, 
            };

            // adding the seed courses
            // and checking if the courses already exist
            // by their Name
            courses.ForEach(c => context.Courses.AddOrUpdate(p => p.Name, c));

            context.SaveChanges();
        }

        private void SeedStudents(StudentSystemDbContext context)
        {
            var students = new List<Student>
            {
                new Student()
                {
                    Name = "Georgi Georgiev",
                    PhoneNumber = "08951242",
                    //Birthday = new DateTime(1992, 1, 12),
                    RegistrationDate = new DateTime(2014, 4, 1)
                },
                new Student()
                {
                    Name = "Maria Vasileva",
                    PhoneNumber = "0883427",
                    Birthday = new DateTime(1990, 4, 16),
                    RegistrationDate = new DateTime(2014, 5, 1)
                },
                new Student()
                {
                    Name = "Petar Ganchev",
                    PhoneNumber = "08953235",
                    Birthday = new DateTime(1991, 7, 1),
                    RegistrationDate = new DateTime(2014, 4, 2)
                },
                new Student()
                {
                    Name = "Tanya Karaivanova",
                    PhoneNumber = "08957454",
                    Birthday = new DateTime(1989, 12, 8),
                    RegistrationDate = new DateTime(2014, 4, 8)
                },
                new Student()
                {
                    Name = "Martin Korkmaz",
                    PhoneNumber = "088532343",
                    Birthday = new DateTime(1995, 5, 5),
                    RegistrationDate = new DateTime(2014, 4, 1)
                }
            };

            students.ForEach(s => context.Students.AddOrUpdate(p => p.Name, s));

            context.SaveChanges();
        }

        private void SeedResources(StudentSystemDbContext context)
        {
            var resources = new List<Resource>
            {
                new Resource()
                {
                    Name = "C# Fundamentals Video",
                    ResourceType = ResourceType.Video,
                    Link = "youtu.be.com/asdad",
                    CourseId = context.Courses.ToList().First(c => c.Name.Equals("C# Basics")).Id
                },
                new Resource()
                {
                    Name = "C# Fundamentals Demos",
                    ResourceType = ResourceType.Document,
                    Link = "www.asddssa.com/homeworks/124",
                    CourseId = context.Courses.ToList().First(c => c.Name.Equals("C# Basics")).Id
                },
                new Resource()
                {
                    Name = "C# OOP, Interfaces Video",
                    ResourceType =ResourceType.Video,
                    Link = "youtu.be.com/bcvbc",
                    CourseId = context.Courses.ToList().First(c => c.Name.Equals("C# OOP")).Id
                },
                new Resource()
                {
                    Name = "C# OOP, Interfaces Demos",
                    ResourceType = ResourceType.Presentation,
                    Link = "www.asddssa.com/homeworks/124oop",
                    CourseId = context.Courses.ToList().First(c => c.Name.Equals("C# OOP")).Id
                },
                new Resource()
                {
                    Name = "HTML Overview",
                    ResourceType = ResourceType.Other,
                    Link = "youtu.be.com/vfdgd",
                    CourseId = context.Courses.ToList().First(c => c.Name.Equals("HTML & CSS")).Id
                },
                new Resource()
                {
                    Name = "HTML Tables, CSS",
                    ResourceType = ResourceType.Presentation,
                    Link = "youtu.be.com/vfdgdzvcx",
                    CourseId = context.Courses.ToList().First(c => c.Name.Equals("HTML & CSS")).Id
                }
            };

            resources.ForEach(r => context.Resoursces.AddOrUpdate(p => p.Name, r));

            context.SaveChanges();
        }

        private void SeedHomeworkSubmissions(StudentSystemDbContext context)
        {
            var homeworks = new List<Homework>
            {
                new Homework()
                {
                    StudentId = context.Students.Where(s => s.Name.Equals("Georgi Georgiev")).FirstOrDefault().Id,
                    CourseId = context.Courses.ToList().First(c => c.Name.Equals("C# Basics")).Id,
                    Content = "Homework for C# Fundamentals",
                    ContentType = ContentType.Zip,
                    DeadLine = new DateTime(2014, 3, 10)
                },
                new Homework()
                {
                    StudentId = context.Students.Where(s => s.Name.Equals("Martin Korkmaz")).FirstOrDefault().Id,
                    CourseId = context.Courses.ToList().First(c => c.Name.Equals("C# Basics")).Id,
                    Content = "C# Fundamentals-Homework",
                    ContentType =ContentType.Pdf,
                    DeadLine = new DateTime(2014, 3, 9)
                },
                new Homework()
                {
                    StudentId = context.Students.Where(s => s.Name.Equals("Tanya Karaivanova")).FirstOrDefault().Id,
                    CourseId = context.Courses.ToList().First(c => c.Name.Equals("HTML & CSS")).Id,
                    Content = "Homework for HTML & CSS",
                    ContentType = ContentType.Zip,
                    DeadLine = new DateTime(2014, 10, 1)
                }
            };

            homeworks.ForEach(h => context.Homeworks.AddOrUpdate(p => p.Content, h));

            context.SaveChanges();
        }
    }
}
