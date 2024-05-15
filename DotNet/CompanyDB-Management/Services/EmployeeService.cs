using Dapper;
using System.Data;
using System.Data.SqlClient;
using CompanyDB_Management.Constants;
using CompanyDB_Management.Model;

namespace CompanyDB_Management.Services
{
    public class EmployeeService
    {
        private readonly IConfiguration _configuration;
        public string? ConnectionString { get; }

        // Constructor for EmployeeService
        public EmployeeService(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<EmployeeModel>> GetAllEmployees()
        {
            // Using a SqlConnection to connect to the database
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync(); // Change to OpenAsync() for async usage

                // Using Dapper to execute the stored procedure asynchronously and retrieve employees
                var employees = await connection.QueryAsync<EmployeeModel>(
                    StoredProcedureConstants.Employee.GetAllEmployees,
                    commandType: CommandType.StoredProcedure
                );

                // Return the list of employees
                return employees;
            }
        }

        // Insert a single employee
        public async Task<EmployeeResponce> AddEmployee(EmployeeModel employee)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                // Execute the stored procedure asynchronously to insert the employee
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeID", employee.Id);
                parameters.Add("@PhoneNumber", employee.PhoneNumber);
                parameters.Add("@FirstName", employee.FirstName);
                parameters.Add("@Department", employee.Department);
                parameters.Add("@LastName", employee.LastName);
                parameters.Add("@Salary", employee.Salary);
                parameters.Add("@Email", employee.Email);

                // Add other parameters as needed

                using (var result = await connection.QueryMultipleAsync(
                    StoredProcedureConstants.Employee.AddEmployees,
                    parameters,
                    commandType: CommandType.StoredProcedure
                ))
                {
                    var errorMessage = result.ReadFirstOrDefault<string>();
                    if (errorMessage != null && errorMessage.StartsWith("Employee with same id already exists"))
                    {
                        return new EmployeeResponce
                        {
                            IsSuccess = false,
                            IsError = true,
                            Message = errorMessage
                        };
                    }
                    else
                    {
                        return new EmployeeResponce
                        {
                            IsSuccess = true,
                            IsError = false,
                            Message = " New Employee  created Successfully..."
                        };

                    }
                }


            }
        }

        //

        public async Task<EmployeeResponce> UpdateEmployee(EmployeeModel employee)
        {

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeID", employee.Id);
                parameters.Add("@PhoneNumber", employee.PhoneNumber);
                parameters.Add("@FirstName", employee.FirstName);
                parameters.Add("@Department", employee.Department);
                parameters.Add("@LastName", employee.LastName);
                parameters.Add("@Salary", employee.Salary);
                parameters.Add("@Email", employee.Email);

                using (var result = await connection.QueryMultipleAsync(
                    StoredProcedureConstants.Employee.UpdateEmployee,
                    parameters,
                    commandType: CommandType.StoredProcedure
                    ))
                {
                    var errorMessage = result.ReadFirstOrDefault<string>();
                    if (errorMessage != null && errorMessage.StartsWith("Employee with specified ID does not exist"))
                    {
                        return new EmployeeResponce
                        {
                            IsSuccess = false,
                            IsError = true,
                            Message = errorMessage
                        };
                    }
                    else
                    {
                        return new EmployeeResponce
                        {
                            IsSuccess = true,
                            IsError = false,
                            Message = "Employee details updated successfully..."
                        };

                    }
                }


            }
        }




        //
        public async Task<EmployeeResponce> DeleteEmployee(string id)
        {
            using var connection = new SqlConnection(ConnectionString);
            {
                await connection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeID", id);

                using (var result = await connection.QueryMultipleAsync(
                    StoredProcedureConstants.Employee.DeleteEmployee,
                    parameters,
                    commandType: CommandType.StoredProcedure
                    ))
                {
                    var errorMessage = result.ReadFirstOrDefault<string>();
                    if (errorMessage != null && errorMessage.StartsWith("Employee  id dose not  exists"))
                    {
                        return new EmployeeResponce
                        {
                            IsSuccess = false,
                            IsError = true,
                            Message = errorMessage
                        };
                    }
                    else
                    {
                        return new EmployeeResponce
                        {
                            IsSuccess = true,
                            IsError = false,
                            Message = "Employee deleted successfully..."
                        };

                    }
                }


            }
        }
    }
}
