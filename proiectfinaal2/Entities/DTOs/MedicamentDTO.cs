using System.Collections.Generic;

namespace proiectfinaal2.Entities.DTOs
{
    public class MedicamentDTO
    {
        public int Id { get; set; }
        public string Denumire { get; set; }
        public int Gramaj { get; set; }

        List<AnimalMedicament> AnimalMedicamente { get; set; }

        public MedicamentDTO(Medicament medicament)
        {
            this.Id = medicament.Id;
            this.Denumire = medicament.Denumire;
            this.Gramaj = medicament.Gramaj;
            this.AnimalMedicamente = new List<AnimalMedicament>();
           
        }
    }
}
