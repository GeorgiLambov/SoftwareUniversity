using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftUniLearningSystem.Data;

namespace SoftwareUniversityLearningSystem
{
    public class TestSiftUniLearningSystem
    {
        static void Main()
        {
            var nikbank = new JuniorTrainer("Nikolay", "Bankin", "8080808080");
            var vKaranf = new SeniorTrainer("Vlado", "Karnfilov", "7070807070");
            Console.WriteLine(nikbank);
            Console.WriteLine(vKaranf);

            nikbank.CreateCourse("OOP");
            vKaranf.CreateCourse("C# Part:2");
            vKaranf.DeleteCourse("C# Part:2");
            Console.WriteLine(new string('*', Console.WindowWidth));

            var student1 = new GradulateStudent("Gosho", "Loshov", "1234567890", 34, 5.60);
            var student2 = new GradulateStudent("Pesho", "Poshov", "1234567890", 12, 3.60);
            var student3 = new GradulateStudent("Mari", "Markova", "1234567890", 1, 4.20);

            var student13 = new DropoutStudent("Niki", "Nikov", "1234567890", 4, 2.00, "low result");
            var student14 = new DropoutStudent("Mari", "Markova", "1234567890", 1, 4.20, "family reason");

            var student11 = new OnlineStudent("Mitko", "Mitkov", "1234567890", 2, 2.60);
            var student21 = new OnsiteStudent("Goro", "Gororv", "1234567890", 2, 5.66);
            student21.Visits = 23;
            var persons = new HashSet<Person>()
            {
                nikbank,
                vKaranf,
                student1,
                student1,
                student11,
                student13,
                student14,
                student2,
                student3,
                student21
            };

            student11.CurrentCourses.Add("C# Part 1");

            var selectedStudents = from person in persons
                                   where person is CurrentStudent
                                   orderby ((Student)person).AverageGrade descending
                                   select person;

            foreach (var student in selectedStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}
