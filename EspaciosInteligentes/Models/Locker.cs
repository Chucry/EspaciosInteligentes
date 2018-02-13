namespace EspaciosInteligentes.Models
{
    public class Locker
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public double Price { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }
        public Store Store { get; set; }
    }
}