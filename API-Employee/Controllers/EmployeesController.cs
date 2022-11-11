using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Employee.DAL;
using API_Employee.DTOs.EmployeeDTOs;
using API_Employee.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Employee.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly ApiDbContext context;

        public EmployeesController(ApiDbContext context)
        {
            this.context = context;
        }

        
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            List<Employee> employees = context.Employees.Include(x => x.Department).ToList();
            return StatusCode(StatusCodes.Status200OK, employees);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Employee? employee = context.Employees.Find(id);
            if (employee is null) return NotFound();
            return StatusCode(StatusCodes.Status200OK , employee);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EmployeeCreateDTO dto)
        {
            if (dto is null) return BadRequest();
            if (context.Departments.Find(dto.DepartmentId) is null) return NotFound(new{
                Message = "No Department Found"
            });

            Employee newEmployee = new Employee
            {
                Name = dto.Name,
                Surname = dto.Surname,
                DepartmentId = dto.DepartmentId
            };

            await context.Employees.AddAsync(newEmployee);
            await context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

