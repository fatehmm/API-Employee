using System;
namespace API_Employee.DTOs.DepartmentDTOs
{
	public class DepartmentCreateDTO
	{
		
		public string Name { get; set; } = null!;

		public string Surname { get; set; } = null!;

        public string AccessCode { get; set; } = null!;

    }
}

