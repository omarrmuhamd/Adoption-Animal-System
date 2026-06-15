using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Entities
{
    public class Animal : BaseEntity
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string HealthStatus { get; set; }
        public bool IsAdopted { get; set; }
        public string ImageUrl { get; set; }



        public int ShelterId { get; set; }
        public Shelter Shelter { get; set; }

        public int AnimalBreedId { get; set; }
        public AnimalBreed AnimalBreed { get; set; }

        public int AnimalTypeId { get; set; }
        public AnimalType AnimalType { get; set; }
    }
}
