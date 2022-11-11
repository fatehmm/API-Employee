using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Employee.DAL;
using API_Employee.DTOs.DepartmentDTOs;
using API_Employee.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Employee.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentsController : Controller
    {
        private readonly ApiDbContext context;

        public DepartmentsController(ApiDbContext context)
        {
            this.context = context;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
             List<Department> departments = await context.Departments.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, departments);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Department? department = await context.Departments.FindAsync(id);
            if (department is null) return NotFound();
            return StatusCode(StatusCodes.Status200OK, department);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DepartmentCreateDTO departmentDTO)
        {
            if (departmentDTO is null) return BadRequest();
            Department newDepartment = new Department
            {
                Name = departmentDTO.Name,
                AccessCode = departmentDTO.AccessCode
            };
            await context.Departments.AddAsync(newDepartment);
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

