namespace StudentSystem.Client
{
    using System;
    using System.Linq;
    using System.Data.Entity;

    using StudentSystem.Data;
    using StudentSystem.Model;
    using StudentSystem.Data.Migrations;

    public class StudentSystemUI
    {
        // Data Source=.;
        static StudentSystemDbContext db = new StudentSystemDbContext();
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
            db.Database.Initialize(true);

            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Presenting some data from the Student System database");
            Console.WriteLine("Created with Code First approach***");
            Console.Write(decorationLine);

            Console.WriteLine("---Printing All Courses---");
            PrintCourses();

            Console.WriteLine("---Printing all students---");
            PrintStudents();

        }

        private static void PrintCourses()
        {
            foreach (var course in db.Courses.Include("Students").Include("Resources").Include("Homeworks"))
            {
                Console.WriteLine("Name: {0}; Description: {1}; Resoursces: {2}; Students: {3}; Homeworks: {4}",
                    course.Name, course.Description,
                    string.Join(", ", course.Resources.Select(r => r.Name)),
                    string.Join(", ", course.Students.Select(s => s.Name)),
                    string.Join(", ", course.Homeworks.Select(h => h.Content))
                    );
            }
        }

        static void PrintStudents()
        {
            foreach (var student in db.Students.Include("Courses").Include("Homeworks"))
            {
                Console.WriteLine("Name: {0}; Phone number: {1}; Courses: {2}; Homeworks: {3}",
                    student.Name, student.PhoneNumber,
                    string.Join(", ", student.Courses.Select(c => c.Name)),
                    string.Join(", ", student.Homeworks.Select(h => new { Name = h.Content })));
            }
        }
    }
}
