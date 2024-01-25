

using EmployeeCrudApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]

        public async Task<ActionResult<List<Employee>>> GetAllEmployee()
        {
            return await _employeeService.GetAllEmployee();
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<List<Employee>>> GetSingleEmployee(int id)
        {
           var result = await _employeeService.GetSingleEmployee(id);
            if(result == null)
            {
                return NotFound("Employee not found");
            }

            return Ok(result);
        }

        [HttpPost]

        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            Console.WriteLine(employee);
            var result = await _employeeService.AddEmployee(employee);
            return Ok(result);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<List<Employee>>> UpdateEmployee(int id, Employee request)
        {
            var result = await _employeeService.UpdateEmployee(id, request);
            if (result == null)
            {
                return NotFound("Employee not found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployee(id);
            if(result == null)
            {
                return NotFound("Employee not found");
            }
            return Ok(result);

        }


    }
}
