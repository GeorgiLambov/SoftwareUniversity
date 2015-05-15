using System;
using System.Linq;
using EntityFramework.Data;

namespace EmployeesByDepartmentAndManager
{
    public class EmployeesByDepartmentAndManager
    {
        public static void Main()
        {
            FindEmployeesByDepartmentAndManager("Sales", "Stephen", "Jiang");
        }

        static void FindEmployeesByDepartmentAndManager(string departmentName, string managerFirstName, string managerLastName)
        {
            using (var db = new SoftUniEntities())
            {
                var employees = db.Employees.Where(
                    e => e.Department.Name == departmentName &&
                        e.ManagerID == (db.Employees.FirstOrDefault(m => m.FirstName == managerFirstName ||
                        m.LastName == managerLastName).EmployeeID));

                foreach (var employee in employees)
                {
                    Console.WriteLine(employee.FirstName + " " + employee.LastName + " -> " + employee.Department.Name);
                }
            }
        }
    }
}
