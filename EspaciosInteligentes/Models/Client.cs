﻿using System;
using System.ComponentModel;

namespace EspaciosInteligentes.Models
{
    public class Client
    {
        public int Id { get; set; }

        [DisplayName("Nombre")]
        public string Name { get; set; }

        [DisplayName("Apellido")]
        public string LastName { get; set; }

        [DisplayName("Correo electrónico")]
        public string Email { get; set; }

        [DisplayName("Contraseña")]
        public string Password { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Número de contacto")]
        public string ContactNumber { get; set; }

        [DisplayName("Ciudad")]
        public City City { get; set; }

        public int CityId { get; set; }
    }
}