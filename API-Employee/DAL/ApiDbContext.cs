using System;
using API_Employee.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Employee.DAL
{
	public class ApiDbContext : DbContext
	{
		//Adding database options
		public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
		{
		}
		//Place to integrate DbSet solutions

		public DbSet<Employee> Employees => Set<Employee>();

		public DbSet<Department> Departments => Set<Department>();
	}
}

