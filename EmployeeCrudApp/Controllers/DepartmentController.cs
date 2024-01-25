using EmployeeCrudApp.Services.DepartmentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        [HttpGet]

        public async Task<ActionResult<List<Department>>> GetAllDepartment()
        {
            var result = await _departmentService.GetAllDepartment();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Department>> GetSingleDepartment(int id)
        {
            var result = await _departmentService.GetSingleDepartment(id);
            if(result == null)
            {
                return NotFound("department not exist");
            }
            return Ok(result);
        }

        [HttpPost]

        public async Task<ActionResult<List<Department>>> AddDepartment(Department department)
        {
            var result = await _departmentService.AddDepartment(department); 
            return Ok(result);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<List<Department>>> UpdateDepartment(int id, Department request)
        {
            var result = await _departmentService.UpdateDepartment(id, request);
            if(result == null) 
            {
                return NotFound("Can not update. department not found");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Department>>> DeleteDepartment(int id)
        {
           var result = await _departmentService.DeleteDepartment(id);
            if(result == null)
            {
                return NotFound("department not found");
            }
            
            
            return Ok(result);
        }
    }
}
