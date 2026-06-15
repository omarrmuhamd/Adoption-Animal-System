using AutoMapper;
using Core.Entities;
using GraduationProject.DTOS;
using GraduationProject.DTOS.AdminCrudForAnimalDTOS;
using Project.Core.Entities;
using static GraduationProject.DTOS.AdminCrudForAnimalDTOS.CreateAnimalDTO;

namespace GraduationProject.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Animal,AnimalToReturnDTO>().ForMember(d=>d.AnimalBreed, o=>o.MapFrom(b=>b.AnimalBreed.Name))
                                                 .ForMember(d => d.AnimalType, o => o.MapFrom(b => b.AnimalType.Name))
                                                 .ForMember(d => d.Shelter, o => o.MapFrom(b => b.Shelter.Name))
                                                 .ForMember(b => b.ImageUrl, o => o.MapFrom<AnimalPictureUrlResolver>());

            CreateMap<AdoptionRequest, AdoptionRequestToReturnDTO>().ForMember(d => d.AnimalName, o => o.MapFrom(s => s.Animal.Name))
                                                                    .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.CreatedAt))
                                                                    .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));

            CreateMap<CreateAnimalDTO, Animal>()
                .ForMember(d => d.IsAdopted, o => o.MapFrom(_ => false))
                .ForMember(d => d.Shelter, o => o.Ignore())
                .ForMember(d => d.AnimalBreed, o => o.Ignore())
                .ForMember(d => d.AnimalType, o => o.Ignore());


            CreateMap<UpdateAnimalDTO, Animal>().ForMember(d => d.Id, o => o.Ignore())
                                                .ForMember(d => d.ShelterId, o => o.Ignore())
                                                .ForMember(d => d.AnimalBreedId, o => o.Ignore())
                                                .ForMember(d => d.AnimalTypeId, o => o.Ignore());

        }
    }
}
