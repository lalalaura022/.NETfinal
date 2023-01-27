using System.Net;

namespace proiectfinaal2.Entities
{
    public class Stapan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Varsta { get; set; }
        public string Sex { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        //public Address Address { get; set; }
    }
}
