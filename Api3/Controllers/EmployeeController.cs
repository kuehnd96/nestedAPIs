using Microsoft.AspNetCore.Mvc;

namespace Api3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        private readonly IList<Employee> _employees;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;

            _employees = new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Title = "CEO",
                    StartDate = DateTime.Now.AddYears(-13),
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Title = "CFO",
                    StartDate = DateTime.Now.AddYears(-8),
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Tony",
                    LastName = "Wilkes",
                    Title = "CIO",
                    StartDate = DateTime.Now.AddYears(-5),
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Dave",
                    LastName = "Keane",
                    Title = "Senior Software Engineer",
                    StartDate = DateTime.Now.AddYears(-2),
                }
            };
        }

        [HttpGet(Name = "GetEmployee")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            await Task.Delay(3000); // simulate long-running task on another thread

            Employee? employee = _employees.SingleOrDefault(e => e.Id == id);

            if (employee == null) return NotFound();

            return Ok(employee);
        }
    }
}