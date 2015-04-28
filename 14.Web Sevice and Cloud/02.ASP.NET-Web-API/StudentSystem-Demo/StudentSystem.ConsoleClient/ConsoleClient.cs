namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using StudentSystem.Data;
    using StudentSystem.Models;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Data;
    using System.Collections.Generic;

    public class ConsoleClient
    {
        public static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student.FirstName);
            }
        }

        public static void Main()
        {
            var data = new StudentsSystemData();

            var courses = data.Courses.All();

            foreach (var course in courses)
            {
                Console.WriteLine(course.Name);
            }

            data.Courses.Add(new Course
            {
                Name = "Repo Pattern",
                Description = "Cool"
            });

            data.SaveChanges();

            var students = data.Students.All();

            Console.WriteLine(students.Count());

            //var masters = data.Students.Where(st => st.Level > 1);
            //PrintStudents(masters);

            //var ivaylos = data.Students.Where(st => st.FirstName == "Ivaylo");
            //PrintStudents(ivaylos);

            //var firstMaster = data.Students.FirstOrDefault(st => st.Level == -5);
            //if (firstMaster == null)
            //{
            //    Console.WriteLine("NULL");
            //}

            //var levels = data.Students.Select(st => new
            //    {
            //        Level = st.Level,
            //        LastName = st.LastName
            //    });

            //foreach (var level in levels)
            //{
            //    Console.WriteLine(level.LastName);
            //}

            //var orderedStudents = data.Students
            //    .OrderBy(st => st.LastName)
            //    .ThenBy(st => st.Level);

            //PrintStudents(orderedStudents);

            //var someQuery = data.Students
            //    .Where(st => st.Level > 0)
            //    .OrderBy(st => st.LastName)
            //    .Select(st => new
            //    {
            //        FirstName = st.FirstName
            //    });

            //var maxLevel = data.Students.Max(st => st.Level);

            //Console.WriteLine(maxLevel);

            //Console.WriteLine(data.Students.Find(2).LastName);

            //data.Courses.Add(new Course
            //{
            //    Name = "Entity Framework",
            //    Description = "Code First"
            //});

            //data.SaveChanges();

            //var entityFrCourse = data.Courses.FirstOrDefault(c => c.Name == "Entity Framework");

            //foreach (var master in masters)
            //{
            //    // entityFrCourse.Students.Add(master);
            //}

            //data.SaveChanges();

            //var activeCourses = data.Courses.Where(c => c.Students.Count() > 0);

            //foreach (var course in activeCourses)
            //{
            //    course.Description = "Code First Is Cool";
            //    Console.WriteLine(course.Name);
            //}

            //data.SaveChanges();

            //var courses = data.Courses.ToList();

            //foreach (var course in courses)
            //{
            //    if (course.Students.Count() == 0)
            //    {
            //        data.Courses.Remove(course);
            //    }
            //}

            //var coursesWithStudents = data.Courses.Include(x => x.Students);

            //data.SaveChanges();

            //var someQuery = data.Students
            //    .Where(st => st.Level > 0)
            //    .OrderBy(st => st.LastName)
            //    .Select(st => new
            //    {
            //        FirstName = st.FirstName
            //    })
            //    .ToList();

            //var courseFirst = data.Courses.FirstOrDefault();

            //var courseEntry = data.Entry(courseFirst);
            //courseEntry.State = EntityState.Detached;

            //data.Courses.Attach(courseFirst);

            //courseFirst.Name = "Entity Framework";

            //data.SaveChanges();
        }
    }
}
