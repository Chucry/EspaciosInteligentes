using System;
using EspaciosInteligentes.Enums;

namespace EspaciosInteligentes.Models
{
    public class PromoCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public PromoCodeType Type { get; set; }
        public Employee CreatedBy { get; set; }
    }
}