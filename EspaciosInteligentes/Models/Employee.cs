using System;
using System.ComponentModel;

namespace EspaciosInteligentes.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [DisplayName("Nombre")]
        public string Name { get; set; }

        [DisplayName("Apellido")]
        public string LastName { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Correo electrónico")]
        public string Email { get; set; }

        [DisplayName("Contraseña")]
        public string Password { get; set; }

        [DisplayName("Teléfono")]
        public string Phone { get; set; }

        [DisplayName("Celular")]
        public string Mobile { get; set; }

        [DisplayName("Departamento")]
        public string Department { get; set; }

        [DisplayName("Puesto")]
        public string Role { get; set; }

        [DisplayName("Fecha de Contratación")]
        public DateTime HireDate { get; set; }

        [DisplayName("Fecha de Terminación")]
        public DateTime? TerminationDate { get; set; }

        [DisplayName("Salario base")]
        public double BaseSalary { get; set; }

        [DisplayName("Dirección")]
        public string Address { get; set; }

        [DisplayName("Colonia")]
        public string Address2 { get; set; }

        [DisplayName("Número de Seguro Social")]
        public string SSN { get; set; }

        [DisplayName("C.U.R.P.")]
        public string CURP { get; set; }

        public string CLABE { get; set; }

        public string FormattedBirthDate => BirthDate.ToString("dd/MM/yyyy");

        public string FormattedHireDate => HireDate.ToString("dd/MM/yyyy");
    }
}