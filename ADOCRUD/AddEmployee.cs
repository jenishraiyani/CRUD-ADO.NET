using BussinessObject;
using DataAccess;
using System.Data.SqlClient;

namespace ADOCRUD
{
    internal class AddEmployee
    {
        public static void AddRecord()
        {
            DataLayer data = new DataLayer();
            Console.WriteLine("\t\t\t\tEnter details employee");
            Console.Write("\t\t\t\tId: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            List<Employee> employeeData = data.GetAllEmployee().Where(emp => emp.ID == employeeId).ToList();

            if(employeeData.Count > 0)
            {
                Console.WriteLine(Program.countMessage);
            }
            else
            {
                Employee employee = Program.UserInput(employeeId);

                int queryResponse = data.AddEmployee(employee);
                if (queryResponse > 0)
                {
                    Console.WriteLine(Program.successMessage);
                }
                else
                {
                    Console.WriteLine(Program.errorMessage);
                }
            }
           
            Program.EmployeeMenu();     
        }
    }
}
