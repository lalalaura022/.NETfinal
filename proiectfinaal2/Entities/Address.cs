namespace proiectfinaal2.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Oras { get; set; }
        public string Strada { get; set; }
        public int Numar { get; set; }
       // public Stapan Stapan { get; set; }
        //public int StapanId { get; set; }
        public Animal Animal { get; set; }
        public int AnimalId { get; set; }
    }
}
