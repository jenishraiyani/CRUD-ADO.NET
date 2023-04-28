using ADOCRUD;
using BussinessObject;
using DataAccess;
using System;
using System.Configuration;
using System.Data.SqlClient;

public class Program
{
    public static string invalidInput = "Please enter valid input!!";
    public static string successMessage = "Details added successfully.";
    public static string deleteMessage = "Record Deleted Successfully.";
    public static string recordMessage = "Employee not found!!";
    public static string dateFormat = "Invalid date format!!";
    public static string errorMessage = "Something went wrong!!";
    public static string confirmMessage = "Are you sure you want to delete this record?? (Yes/No)::";
    public static string countMessage = "Employee already exist.";
 

    public static void Main(string[] args)
    {
        EmployeeMenu();  
    }

    public static void EmployeeMenu()
    {
        Console.WriteLine("\n\t\t\t\t========================================================");
        Console.WriteLine("\t\t\t\t\t\t Manage Employee");
        Console.WriteLine("\t\t\t\t========================================================");
        Console.WriteLine("\n\t\t\t\t1. Display Employee Details");
        Console.WriteLine("\n\t\t\t\t2. Add Employee");
        Console.WriteLine("\n\t\t\t\t3. Delete Employee");
        Console.WriteLine("\n\t\t\t\t4. Update Employee");
        Console.Write("\n\t\t\t\tChoose Any One Option: ");

        try
        {
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Clear();
                    GetEmployeeDetails.GetRecord();
                    break;
                case 2:
                    Console.Clear();
                    AddEmployee.AddRecord();
                    break;
                case 3:
                    Console.Clear();
                    DisplayRecord(0);
                    break;
                case 4:
                    Console.Clear();
                    DisplayRecord(1);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine(invalidInput);
                    break;
            }
        }
        
        catch (Exception)
        {
            Console.Clear();
            Console.WriteLine(invalidInput);        
        }
        EmployeeMenu();
    }

    public static void DisplayRecord(int action)
    {

        try
        {
            Console.Write("\t\t\t\tEnter Employee ID: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            DataLayer dataLayer = new DataLayer();
            List<Employee> employeeData = dataLayer.GetAllEmployee().Where(emp => emp.ID == employeeId).ToList();

            if (employeeData.Count == 1)
            {
                foreach (Employee employee in employeeData)
                {
                    Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4}  \t | {5} \t | {6} \t  | {7} ",
                        employee.ID, employee.Name, employee.Department, employee.Salary,
                        employee.Gender, employee.Age, employee.City, employee.JoiningDate));
                }

                if(action == 0)
                {
                    DeleteEmployee.DeleteRecord(employeeId);
                }
                else
                {
                    UpdateEmployee.UpdateRecord(employeeId);
                }
            }
            else
            {
                Console.WriteLine(recordMessage);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine(invalidInput);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        EmployeeMenu(); 
    }

    public static Employee UserInput(int employeeId)
    {
        Employee employee = new Employee();

        try
        {
        
            Console.Write("\t\t\t\tFull Name: ");
            string employeeName = Console.ReadLine();
            Console.Write("\t\t\t\tDepartment: ");
            string employeeDepartment = Console.ReadLine();
            Console.Write("\t\t\t\tSalary: ");
            double employeeSalary = Convert.ToDouble(Console.ReadLine());
            Console.Write("\t\t\t\tGender: ");
            string employeeGender = Console.ReadLine();
            Console.Write("\t\t\t\tAge: ");
            int employeeAge = Convert.ToInt32(Console.ReadLine());
            Console.Write("\t\t\t\tCity: ");
            string employeeCity = Console.ReadLine();
           
            
            DateTime inputDate = DateTime.MinValue;
            
            do
            {
                Console.Write("\t\t\t\tJoining Date: ");
                string strDateString = Console.ReadLine();
                if (!DateTime.TryParse(strDateString, out inputDate))
                {
                    Console.WriteLine(dateFormat);
                }

            } while (inputDate == DateTime.MinValue);

            string employeeJoiningDate = inputDate.ToString("yyyy-MM-dd");

            employee.ID = employeeId;
            employee.Name = employeeName;
            employee.Department = employeeDepartment;
            employee.Age = employeeAge;
            employee.Gender = employeeGender;
            employee.City = employeeCity;
            employee.Salary = employeeSalary;
            employee.JoiningDate = employeeJoiningDate;
            return employee;
          
        }
        catch (FormatException ex)
        {
            Console.WriteLine(invalidInput);
            UserInput(employeeId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            UserInput(employeeId);
        }
        return employee;
    }

}