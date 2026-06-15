namespace GraduationProject.DTOS.AdminCrudForAnimalDTOS
{
    public class CreateAnimalDTO
    {
      
            public string Name { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public string HealthStatus { get; set; }

            public int ShelterId { get; set; }
            public int AnimalBreedId { get; set; }
            public int AnimalTypeId { get; set; }

            public string ImageUrl { get; set; }
        
    }
}
