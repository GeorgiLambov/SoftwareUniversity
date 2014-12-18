namespace _03_14ClassStudent
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class TestStudentClass
    {
        static void Main()
        {
            // Problem 3. Class Student

            List<Student> students = new List<Student> 
            {
                new Student("Dimitar", "Angelov", 33, "223344", "+359 4 244 789 789", "mitaka@abv.bg", new List<int>{5,3,4}, 2, "Plovdiv"),
                new Student("Milena", "Kirova", 18, "215314", "+359 5 041 119 789", "mariika@abv.bg", new List<int>{2,4,2,3,4,2}, 1, "Sofia"),
                new Student("Ivan", "Ivanov", 23, "203814", "+359 2 884 578 173", "tialoto@bitex.bg", new List<int>{6,4,6,3,6,6,6}, 2, "Sofia"), 
                new Student("Stefan", "Popov", 38, "203114", "+359 0 114 478 173", "tancho@abv.bg", new List<int>{6,6,6}, 1, "Plovdiv"),
                new Student("Mimi", "Voche", 28, "913344", "+359 0 100 000 003", "mimi@sport.bg", new List<int>{2,3,4,5,2,3,4,5,6}, 2, "Varna"),
                new Student("Antonia", "Parvanova", 38, "513344", "+359 6 443 000 003", "anti@abv.bg", new List<int>{6,2,3,4,5,6},2, "Varna"),
                new Student("Asia", "Manova", 34, "203314", "+359 2 223 222 003", "stv@abv.bg", new List<int>{6,2,6,6,6,6,}, 1, "Varna"),
                new Student("Diana", "Petrova", 19, "203914", "+359 6 678 000 003", "trichka@dir.bg", new List<int>{2,3,4,5}, 1, "Sofia"),
            };
            //students.ForEach(std => Console.WriteLine(std.ToString()));

            //// Problem 4.Students by Group
            //Console.WriteLine("Problem 4. Students by Group");
            //var groupByName =
            //    from std in students
            //    where std.GroupNumber == 2
            //    orderby std.FirstName
            //    select std;
            ////groupByName.ToList().ForEach(s => Console.WriteLine(s.ToString()));
            //foreach (var item in groupByName)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            ////  Problem 5.Students by First and Last Name
            //Console.WriteLine(" Problem 5.	Students by First and Last Name ");

            //var firstNameBeforeLastName = from std in students
            //                              where std.FirstName.CompareTo(std.LastName) < 0
            //                              select std;

            //foreach (var item in firstNameBeforeLastName)
            //{
            //    Console.WriteLine(item.ToString());
            //}


            ////Problem 6.Students by Age
            //Console.WriteLine("Problem 6 Students by Age");

            //var studentsByAge =
            //    from std in students
            //    where std.Age > 18 && std.Age < 24
            //    select new { std.FirstName, std.LastName, std.Age };

            //foreach (var item in studentsByAge)
            //{
            //    Console.WriteLine("{0} {1}, age: {2}", item.FirstName, item.LastName, item.Age);
            //}

            ////Problem 7.Sort Students
            //Console.WriteLine("Problem 7.Sort Students");

            //var sortedStudents = students.OrderByDescending(st => st.FirstName).ThenByDescending(st => st.LastName);

            //var sortedStudentsLINQ = from stud in students
            //                         orderby stud.FirstName descending, stud.LastName descending
            //                         select stud;

            //Console.WriteLine("\nStudents sorted descending by names: ");
            //foreach (var item in sortedStudents)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            ////Problem 8.Filter Students by Email Domain
            //Console.WriteLine("Problem 8.Filter Students by Email Domain");

            //var withAbvEmail = from std in students
            //                   where std.Email.Contains("@abv.bg")
            //                   select std;

            //Console.WriteLine("\nStudents with email in abv.bg: ");
            //foreach (var item in withAbvEmail)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            ////Problem 9.Filter Students by Phone
            //Console.WriteLine("Problem 9.Filter Students by Phone");
            //var withSofiaPhone = from std in students
            //                     where std.Phone.StartsWith("02") ||
            //                     std.Phone.StartsWith("+3592") ||
            //                     std.Phone.StartsWith("+359 2")
            //                     select std;
            //foreach (var item in withSofiaPhone)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            ////Problem 10.Excellent Students
            //Console.WriteLine("Problem 10.Excellent Students");

            //var excellent = from st in students
            //                where st.Marks.Contains(6)
            //                select new { Fullname = st.FirstName + " " + st.LastName, Marks = st.Marks };
            //foreach (var item in excellent)
            //{
            //    Console.WriteLine("{0} {{ {1} }}", item.Fullname, string.Join(", ", item.Marks));
            //}

            ////Problem 11.Weak Students
            //Console.WriteLine("Problem 11.Weak Students");

            //var twoTwos = students.Where(st => st.Marks.Where(m => m == 2).Count() == 2);

            //foreach (var item in twoTwos)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            ////Problem 12.Students Enrolled in 2014
            //Console.WriteLine("Problem 12.Students Enrolled in 2014");

            //var enrolled2014 = from st in students
            //                   where st.FucultyNumber.EndsWith("14")
            //                   select st;

            //foreach (var item in enrolled2014)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            // Problem 13.* Students by Groups
            Console.WriteLine("Problem 13.* Students by Groups");

            var groupedByName = from std in students
                                group std by std.GroupName into g
                                select new { GroupName = g.Key, students = g.ToList() };
            foreach (var item in groupedByName)
            {
                Console.WriteLine(item.GroupName);
                Console.WriteLine("\t{0}", string.Join("\n\t", item.students));
            }


            // Problem 14.* Students Joined to Specialties
            //Console.WriteLine("Problem 14.* Students Joined to Specialties");

            //var specialties = new List<StudentSpecialty>() 
            //{ 
            //new StudentSpecialty("Web Developer", "203314"),
            //new StudentSpecialty("PHP Developer", "203814"),
            //new StudentSpecialty("Web Developer", "203114"),
            //new StudentSpecialty("PHP Developer", "203914"),
            //new StudentSpecialty("QA Inngineer", "203314"),
            //new StudentSpecialty("Java Developer", "203914"),
            //new StudentSpecialty("Java Developer", "734115")
            //};

            //var studentsSpecilty = from std in students
            //                       join sp in specialties
            //                       on std.FucultyNumber equals sp.FacultyNumber
            //                       orderby std.FirstName
            //                       select new
            //                       {
            //                           FullName = std.FirstName + " " + std.LastName,
            //                           FacNumber = std.FucultyNumber,
            //                           Specialty = sp.SpecialtyName

            //                       };
            //foreach (var item in studentsSpecilty)
            //{
            //    Console.WriteLine("{0,-20} - {1,-10} - {2}", item.FullName, item.FacNumber, item.Specialty);
            //}
        }
    }
}
