using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EspaciosInteligentes.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Locker Locker { get; set; }
        public Ticket Ticket { get; set; }
    }
}