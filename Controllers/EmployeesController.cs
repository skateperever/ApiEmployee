using ApiEmployee.Interfaces;
using ApiEmployee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IDataEmployee _dataEmployee;
        public EmployeesController(IDataEmployee dataEmployee)
        {
            _dataEmployee = dataEmployee;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = new List<Employee>();

                employees = await _dataEmployee.GetAllEmployees();

                if (employees.Count <= 0)
                {
                    return NotFound();
                }

                return Ok(employees);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                List<Employee> employees = await _dataEmployee.GetEmployee(id);

                Employee employee = employees.FirstOrDefault(x => x.EmployeeId == id);

                return Ok(employee);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmployee([FromBody] Employee employee)
        {
            try
            {
                await _dataEmployee.InsertEmployee(employee);

                return Ok(employee);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            try
            {
                await _dataEmployee.UpdateEmployee(id, employee);               

                return Ok(new { message = "Employee updated"});
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id, [FromBody] Employee employee)
        {
            try
            {
                var employees = await _dataEmployee.GetAllEmployees();

                var employeeId = employees.ToList().Find(x => x.EmployeeId == id);

                if (employeeId == null)
                {
                    return NotFound();
                }

                await _dataEmployee.DeleteEmployee(id);

                return Ok(new { message = "Employee deleted"});
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
