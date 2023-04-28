using BussinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOCRUD
{
    internal class GetEmployeeDetails
    {
        public static void GetRecord()
        {
            DataLayer dataLayer = new DataLayer();
            List<Employee> employeeData = dataLayer.GetAllEmployee();

            foreach (Employee employee in employeeData)
            {
                Console.WriteLine(String.Format("|{0,5}| {1,20} |{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}|",
                    employee.ID, employee.Name, employee.Department,employee.Salary,
                    employee.Gender, employee.Age, employee.City, employee.JoiningDate));
            }

            Program.EmployeeMenu();
        }
    }
}
