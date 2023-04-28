
using BussinessObject;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace DataAccess
{
    public class DataLayer
    {
        string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;
        

        public int AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand insertQuery = new SqlCommand("spAddEmployee", con);
                insertQuery.CommandType = System.Data.CommandType.StoredProcedure;
                insertQuery.Parameters.AddWithValue("@Id", employee.ID);
                insertQuery.Parameters.AddWithValue("@Name", employee.Name);
                insertQuery.Parameters.AddWithValue("@Department", employee.Department);
                insertQuery.Parameters.AddWithValue("@Salary", employee.Salary);
                insertQuery.Parameters.AddWithValue("@Gender", employee.Gender);
                insertQuery.Parameters.AddWithValue("@Age", employee.Age);
                insertQuery.Parameters.AddWithValue("@City", employee.City);
                insertQuery.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);

                con.Open();

                int numberOfRecords = insertQuery.ExecuteNonQuery();
                return numberOfRecords;       
            }
        }

        public int UpdateEmployee(Employee employee,int employeeId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand updateQuery = new SqlCommand("spUpdateEmployee", con);
                updateQuery.CommandType = System.Data.CommandType.StoredProcedure;
                updateQuery.Parameters.AddWithValue("@Id", employeeId);
                updateQuery.Parameters.AddWithValue("@Name", employee.Name);
                updateQuery.Parameters.AddWithValue("@Department", employee.Department);
                updateQuery.Parameters.AddWithValue("@Salary", employee.Salary);
                updateQuery.Parameters.AddWithValue("@Gender", employee.Gender);
                updateQuery.Parameters.AddWithValue("@Age", employee.Age);
                updateQuery.Parameters.AddWithValue("@City", employee.City);
                updateQuery.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);

                con.Open();
                int numberOfRecords = updateQuery.ExecuteNonQuery();
                return numberOfRecords;
            }
        }

        public int DeleteEmployee(int employeeId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand deleteQuery = new SqlCommand("spDeleteEmployee", con);
                deleteQuery.CommandType = System.Data.CommandType.StoredProcedure;
                deleteQuery.Parameters.AddWithValue("@Id", employeeId);
                con.Open();
                int numberOfRecords = deleteQuery.ExecuteNonQuery();
                return numberOfRecords;
            }
        } 
        public List<Employee> GetAllEmployee()
        {
            List<Employee> list = new List<Employee>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand selectQuery = new SqlCommand("spGetEmployeeData", con);
                selectQuery.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = selectQuery.ExecuteReader();
             
                Employee employee;
                while (reader.Read())
                {
                    employee = new Employee();
                    employee.ID = (int)reader["Id"];
                    employee.Name = reader["Name"].ToString();
                    employee.Department = reader["Department"].ToString();
                    employee.Salary = (double)reader["Salary"];
                    employee.Gender = reader["Gender"].ToString();
                    employee.Age = (int)reader["Age"];
                    employee.City = reader["City"].ToString();
                    employee.JoiningDate = Convert.ToDateTime(reader["JoiningDate"]).ToString("dd/MM/yyyy");
                    list.Add(employee);
                }

                return list;
            }
   
        }

    }
}