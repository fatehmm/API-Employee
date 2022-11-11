using System;
using System.Security.Cryptography.X509Certificates;

namespace API_Employee.DTOs.EmployeeDTOs
{
    public class EmployeeCreateDTO
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        
        public int DepartmentId { get; set; }
    }
}


