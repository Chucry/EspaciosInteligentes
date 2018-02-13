using System;

namespace EspaciosInteligentes.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string ContactNumber { get; set; }
        public City City { get; set; }
    }
}