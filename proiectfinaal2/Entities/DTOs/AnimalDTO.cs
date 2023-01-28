using System.Collections.Generic;

namespace proiectfinaal2.Entities.DTOs
{
    public class AnimalDTO
    {
        public int Id { get; set; }
        public string Denumire { get; set; }
        public int Varsta { get; set; }
        public int Kg { get; set; }
        public Address Address { get; set; }
        public List<Stapan> Stapani { get; set; }
        public List<AnimalMedicament> AnimalMedicamente { get; set; }
        public AnimalDTO(Animal animal)
        {
            this.Id = animal.Id;
            this.Denumire = animal.Denumire;
            this.Varsta = animal.Varsta;
            this.Kg = animal.Kg;
            this.Address = animal.Address;
            this.Stapani = new List<Stapan>();
            this.AnimalMedicamente = new List<AnimalMedicament>();
        }
    }
}
