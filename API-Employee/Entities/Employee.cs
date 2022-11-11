using System;
namespace API_Employee.Entities
{
    public class Employee : BaseEntity
	{
		
		public string Name { get; set; } = null!;

		public string Surname { get; set; } = null!;

		public int DepartmentId { get; set; }

		public Department Department { get; set; } = null!;

		
	}
}

