using Microsoft.AspNetCore.Mvc;
using CompanyDB_Management.Model;
using CompanyDB_Management.Services;

namespace CompanyDB_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/employee
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {

            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);


        }

        // POST: api/employee
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeModel employee)
        {
            var result = await _employeeService.AddEmployee(employee);
            return Ok(result);

        }

        [HttpPatch]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeModel employee)
        {
            var result = await _employeeService.UpdateEmployee(employee);
            return Ok(result);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            var result = await _employeeService.DeleteEmployee(id);
            return Ok(result);
        }

    }
}


