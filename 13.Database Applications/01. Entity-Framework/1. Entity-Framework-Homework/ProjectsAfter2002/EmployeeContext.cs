namespace ProjectsAfter2002
{
    using System;
    using System.Linq;
    using EntityFramework.Data;

    public class EmployeeContext
    {
        public static void FindEmployeesWithProjects(int projectStartDateYear)
        {
            var db = new SoftUniEntities();

            var employees = from e in db.Employees
                            where e.Projects.Any(p => p.StartDate.Year == projectStartDateYear)
                            select e;

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FirstName + " " + employee.LastName);
            }

            Console.WriteLine(employees.Count());
        }
    }
}
