using BussinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOCRUD
{
    internal class DeleteEmployee
    {
        public static void DeleteRecord(int employeeId)
        {

            DataLayer dataLayer = new DataLayer();
            Console.Write(Program.confirmMessage);
            string userResponse = Console.ReadLine();

            if (userResponse.ToLower() == "yes")
            {
                int queryResponse = dataLayer.DeleteEmployee(employeeId);
                if (queryResponse > 0)
                {
                    Console.WriteLine(Program.deleteMessage);
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
