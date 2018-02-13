using System;

namespace EspaciosInteligentes.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public double BaseSalary { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string SSN { get; set; }
        public string CURP { get; set; }
        public string CLABE { get; set; }
    }
}