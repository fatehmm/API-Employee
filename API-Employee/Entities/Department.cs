using System;
namespace API_Employee.Entities
{
	public class Department : BaseEntity
	{
		public string Name { get; set; } = null!;

		public string AccessCode { get; set; } = null!;


		public ICollection<Employee> Employees { get; set; } = null!;
	}
}

