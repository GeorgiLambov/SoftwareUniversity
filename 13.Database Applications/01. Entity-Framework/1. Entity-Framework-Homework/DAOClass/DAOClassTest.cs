namespace DAOClass
{
    using System;
    using EntityFramework.Data;
    public class DAOClassTest
    {
        public static void Main()
        {
            var employee = new Employee
            {
                FirstName = "Georgi",
                MiddleName = "Georgiev",
                LastName = "Georgiev",
                HireDate = new DateTime(2015, 03, 09),
                JobTitle = "Programmer",
                DepartmentID = 1,
                Salary = 2560
            };

            //DAOClass.InsertEmployee(employee);

            //DAOClass.RemoveEmployeeById(296);

            DAOClass.UpdateEmployeeSalaryByEmployeeId(296, 3000);
        }
    }
}
