namespace EmployeesWithProjectsAfter2002
{
    using System;
    using EntityFramework.Data;
    using System.Linq;

    public class NativeSqlQuery
    {
        public static void Main()
        {
            using (var db = new SoftUniEntities())
            {
                var query = @"SELECT *
                                FROM Employees e JOIN EmployeesProjects ep
                                ON e.EmployeeID = ep.EmployeeID
                                JOIN Projects p 
                                ON ep.ProjectID = p.ProjectID
                                WHERE YEAR(p.StartDate) = '2002'";

                var employees = db.Employees.SqlQuery(query).Distinct();

                foreach (var employee in employees)
                {
                    Console.WriteLine(employee.FirstName + " " + employee.LastName);
                }

                Console.WriteLine("Employees Count: " + employees.Count());
            }
        }
    }
}
