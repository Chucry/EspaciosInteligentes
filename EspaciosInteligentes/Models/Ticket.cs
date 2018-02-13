using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EspaciosInteligentes.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public double Discount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double SubTotal { get; set; }
        public double Taxes { get; set; }
        public double Total { get; set; }
        public PromoCode PromoCode { get; set; }
        public IList<Sale> Sales { get; set; }
    }
}