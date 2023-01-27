using proiectfinaal2.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace proiectfinaal2.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Denumire { get; set; }

        public int Varsta { get; set; }
        public int Kg { get; set; }

        public Address Address { get; set; }

        public ICollection<Stapan> Stapani { get; set; }

        public ICollection<AnimalMedicament> AnimalMedicamente { get; set; }
    }
}
