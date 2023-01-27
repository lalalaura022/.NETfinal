using System.Collections.Generic;

namespace proiectfinaal2.Entities
{
    public class Medicament
    {
        public int Id { get; set; }
        public string Denumire { get; set; }
        public int Gramaj { get; set; }

        public ICollection<AnimalMedicament> AnimalMedicamente { get; set; }
    }
}
