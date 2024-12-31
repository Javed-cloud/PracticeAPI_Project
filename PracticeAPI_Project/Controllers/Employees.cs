using Microsoft.AspNetCore.Mvc;
using DapperApiDemo.Models;
using DapperApiDemo.Repositories;

namespace DapperApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeRepository _repository;

        public EmployeesController(EmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _repository.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _repository.GetEmployeeById(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }
    }
}
