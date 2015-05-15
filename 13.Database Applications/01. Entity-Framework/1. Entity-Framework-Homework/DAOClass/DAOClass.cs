namespace DAOClass
{
    using System;
    using EntityFramework.Data;

    public class DAOClass
    {
        public static void InsertEmployee(Employee employee)
        {
            var db = new SoftUniEntities();
            db.Employees.Add(employee);
            db.SaveChanges();
            Console.WriteLine(employee.FirstName + " " + employee.LastName + " Inserted!!!");
        }

        public static void RemoveEmployeeById(int employeeId)
        {
            var db = new SoftUniEntities();
            var employee = db.Employees.Find(employeeId);
            db.Employees.Remove(employee);
            db.SaveChanges();
            Console.WriteLine(employee.FirstName + " " + employee.LastName + " Deleted!!!");
        }

        public static void UpdateEmployeeSalaryByEmployeeId(int id, decimal newSalary)
        {
            var db = new SoftUniEntities();
            var employee = db.Employees.Find(id);
            employee.Salary = newSalary;
            db.SaveChanges();
            Console.WriteLine(employee.FirstName + " " + employee.LastName + " new salary -> " + newSalary);
        }
    }
}
