using System;
using System.Collections.Generic;

namespace proiectfinaal2.Entities.DTOs
{
    public class StapanDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Varsta { get; set; }
        public string Sex { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        public StapanDTO(Stapan stapan)
        {
            this.Id = stapan.Id;
            this.Name = stapan.Name;
            this.Varsta = stapan.Varsta;
            this.Sex = stapan.Sex;
            this.AnimalId = stapan.AnimalId;
            this.Animal = new Animal();
        }
    }
}
