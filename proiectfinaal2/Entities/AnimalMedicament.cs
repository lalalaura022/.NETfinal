namespace proiectfinaal2.Entities
{
    public class AnimalMedicament
    {
        public int AnimalId { get; set; }
        public int MedicamentId { get; set; }
        public Animal Animal { get; set; }
        public Medicament Medicament { get; set; }
    }
}
