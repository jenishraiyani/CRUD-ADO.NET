using BussinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOCRUD
{
    internal class UpdateEmployee
    {
        public static void UpdateRecord(int employeeId)
        {
            Employee employee = Program.UserInput(employeeId);
            DataLayer data = new DataLayer();
            int queryResponse = data.UpdateEmployee(employee, employeeId);
            if (queryResponse > 0)
            {
                Console.WriteLine(Program.successMessage);
            }
            else
            {
                Console.WriteLine(Program.errorMessage);
            }
            Program.EmployeeMenu();
        }
    }
}
