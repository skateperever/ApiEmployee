using ApiEmployee.Interfaces;
using ApiEmployee.Models;
using System.Data;
using System.Data.SqlClient;

namespace ApiEmployee.Data
{
    public class DataEmployee : IDataEmployee
    {
        private string connectionString;

        public DataEmployee(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> employeeList = new List<Employee>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_SelectEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    await con.OpenAsync();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        Employee emp = new Employee
                        {
                            EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                            EmployeeName = rdr["EmployeeName"].ToString(),
                            Address = rdr["Address"].ToString(),
                            City = rdr["City"].ToString(),
                            Zipcode = rdr["Zipcode"].ToString(),
                            Country = rdr["Country"].ToString(),
                            Skillsets = rdr["Skillsets"].ToString(),
                            Phone = rdr["Phone"].ToString(),
                            Email = rdr["Email"].ToString(),
                            Avatar = rdr["Avatar"].ToString(),
                        };

                        employeeList.Add(emp);
                    }

                    await con.CloseAsync();

                    return employeeList;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<List<Employee>> GetEmployee(int id)
        {
            List<Employee> employeeList = new List<Employee>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_SelectEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("employeeId", id);

                    await con.OpenAsync();

                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                    while(rdr.Read())
                    {
                        Employee emp = new Employee
                        {
                            EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                            EmployeeName = rdr["EmployeeName"].ToString(),
                            Address = rdr["Address"].ToString(),
                            City = rdr["City"].ToString(),
                            Zipcode = rdr["Zipcode"].ToString(),
                            Country = rdr["Country"].ToString(),
                            Skillsets = rdr["Skillsets"].ToString(),
                            Phone = rdr["Phone"].ToString(),
                            Email = rdr["Email"].ToString(),
                            Avatar = rdr["Avatar"].ToString(),
                        };

                        employeeList.Add(emp);
                    }
                    await con.CloseAsync(); 
                    return employeeList;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> InsertEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_InsertEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("employeeName", employee.EmployeeName);
                    cmd.Parameters.AddWithValue("address", employee.Address);
                    cmd.Parameters.AddWithValue("city", employee.City);
                    cmd.Parameters.AddWithValue("zipcode", employee.Zipcode);
                    cmd.Parameters.AddWithValue("country", employee.Country);
                    cmd.Parameters.AddWithValue("skillsets", employee.Skillsets);
                    cmd.Parameters.AddWithValue("phone", employee.Phone);
                    cmd.Parameters.AddWithValue("email", employee.Email);
                    cmd.Parameters.AddWithValue("avatar", employee.Avatar);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    await con.CloseAsync();
                }

                return 1;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateEmployee", con);
                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("employeeId", employee.EmployeeId);
                    cmd.Parameters.AddWithValue("employeeName", employee.EmployeeName);
                    cmd.Parameters.AddWithValue("address", employee.Address);
                    cmd.Parameters.AddWithValue("city", employee.City);
                    cmd.Parameters.AddWithValue("zipcode", employee.Zipcode);
                    cmd.Parameters.AddWithValue("country", employee.Country);
                    cmd.Parameters.AddWithValue("skillsets", employee.Skillsets);
                    cmd.Parameters.AddWithValue("phone", employee.Phone);
                    cmd.Parameters.AddWithValue("email", employee.Email);
                    cmd.Parameters.AddWithValue("avatar", employee.Avatar);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    await con.CloseAsync();
                }

                return 1;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<int> DeleteEmployee(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("employeeId", id);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    await con.CloseAsync();
                }

                return 1;
            
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
