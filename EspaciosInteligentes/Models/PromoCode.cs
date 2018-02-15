using System;
using System.ComponentModel;
using EspaciosInteligentes.Enums;

namespace EspaciosInteligentes.Models
{
    public class PromoCode
    {
        public int Id { get; set; }

        [DisplayName("Código")]
        public string Code { get; set; }

        [DisplayName("Cantidad")]
        public int Amount { get; set; }

        [DisplayName("Descripción")]
        public string Description { get; set; }

        [DisplayName("Fecha de Expiración")]
        public DateTime ExpirationDate { get; set; }

        [DisplayName("Fecha de Creación")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Tipo")]
        public PromoCodeType Type { get; set; }

        [DisplayName("Creado por")]
        public Employee CreatedBy { get; set; }
    }
}