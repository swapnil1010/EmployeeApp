using EmployeeApp.Models;
using EmployeeApp.Repositories.Interaces;
using System.Data.SqlClient;

namespace EmployeeApp.Repositories.Implemetation
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Employees WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Employee employee = new Employee
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Address = (string)reader["Address"],
                                Mobile = (string)reader["Mobile"],
                                DOB = (string)reader["DOB"],
                            };

                            return employee;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
             
            }
            
            return null;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Employees";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Address = (string)reader["Address"],
                                Mobile = (string)reader["Mobile"],
                                DOB = (string)reader["DOB"],

                            };

                            employees.Add(employee);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            

            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Employees (Name, Address, Mobile,DOB) VALUES (@Name, @Address, @Mobile,@DOB)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Mobile", employee.Mobile);
                    command.Parameters.AddWithValue("@DOB", employee.DOB);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Employees SET Name = @Name, Address = @Address, Mobile = @Mobile , DOB = @DOB WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Mobile", employee.Mobile);
                    command.Parameters.AddWithValue("@DOB", employee.DOB);
                    command.Parameters.AddWithValue("@Id", employee.Id);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
           
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Employees WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
