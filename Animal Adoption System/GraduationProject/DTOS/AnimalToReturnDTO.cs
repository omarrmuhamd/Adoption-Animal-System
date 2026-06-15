using Core.Entities;

namespace GraduationProject.DTOS
{
    public class AnimalToReturnDTO
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string HealthStatus { get; set; }
        public bool IsAdopted { get; set; }
        public string ImageUrl { get; set; }



        public int ShelterId { get; set; }
        public string Shelter { get; set; }

        public int AnimalBreedId { get; set; }
        public string AnimalBreed { get; set; }

        public int AnimalTypeId { get; set; }
        public string AnimalType { get; set; }








    }
}
