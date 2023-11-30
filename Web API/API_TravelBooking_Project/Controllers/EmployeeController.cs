using API_TravelBooking_Project.Models;
using API_TravelBooking_Project.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TravelBooking_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            IEnumerable<Employee> lstemp = await _repository.GetEmployees();
            if (lstemp != null)
            {
                return Ok(lstemp);
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            Employee lstemp = await _repository.GetEmployeeById(id);
            if (lstemp != null)
            {
                return Ok(lstemp);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromBody] Employee emp)
        {
            if (emp == null)
            {
                return BadRequest();
            }
            await _repository.AddEmployee(emp);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = emp.EmpId }, emp);

        }
        //PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, [FromBody] Employee emp)
        {
            Console.WriteLine($"{emp.EmpId}, {emp.EmpFirstName}, {emp.EmpLastName}, {emp.EmpDob}, {emp.EmpAddress}, {emp.EmpContact}");
            await _repository.UpdateEmployee(emp, id);
            return Ok(emp);

        }
        //Delete: api/Movie/5
        [HttpDelete("{id}")]
        
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            Employee emp = await _repository.GetEmployeeById(id);
            if (emp != null)
            {
                _repository.DeleteEmployee(id);
                //return NoContent();
                return Ok();
            }
            return NotFound();
        }
    }
}
