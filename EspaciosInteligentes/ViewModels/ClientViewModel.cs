using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EspaciosInteligentes.Models;

namespace EspaciosInteligentes.ViewModels
{
    public class ClientViewModel
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

        public IList<SelectListItem> CityList { get; set; }
    }
}