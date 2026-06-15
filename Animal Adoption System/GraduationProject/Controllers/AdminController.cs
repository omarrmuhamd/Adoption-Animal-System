using AutoMapper;
using GraduationProject.DTOS;
using GraduationProject.DTOS.AdminCrudForAnimalDTOS;
using GraduationProject.Errors;
using GraduationProject.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Entities;
using Project.Core.Entities.Identity;
using Project.Core.Enums;
using Project.Core.Repositories;
using Project.Core.Specifications.AdoptSpec;
using static GraduationProject.DTOS.AdminCrudForAnimalDTOS.CreateAnimalDTO;

namespace GraduationProject.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]

    public class AdminController : BaseController
    {
        private readonly IGenericRepository<AdoptionRequest> _adoptionRepo;
        private readonly IGenericRepository<Animal> _animalrep;
        private readonly UserManager<AppUser> _userManager;


        public AdminController(IGenericRepository<AdoptionRequest> adoptionRepo , IGenericRepository<Animal> animalrep , UserManager<AppUser> userManager)
        {

            _adoptionRepo = adoptionRepo;
            _animalrep = animalrep;
            _userManager = userManager;
        }

        [HttpGet("AllRequests")]
        public async Task<IActionResult> GetAllRequests()
        {
            var requests = await _adoptionRepo.GetAllWithSpecification(new AdoptionByUserSpec());

            var result = new List<AdoptionRequestToReturnDTO>();

            foreach (var request in requests)
            {
                var user = await _userManager.FindByIdAsync(request.UserId);

                result.Add(new AdoptionRequestToReturnDTO
                {
                    Id = request.Id,
                    AnimalName = request.Animal.Name,
                    UserName = user?.DisplayName,
                    Status = request.Status.ToString(),
                    CreatedAt = request.CreatedAt
                });
            }

            return Ok(result);
        }




        [HttpPut("AcceptRequest/{id}")]
        public async Task<IActionResult> AcceptAdoption(int id)
        {
            var request = await _adoptionRepo.GetById(id);

            if (request == null)
                return NotFound(new ApiResponse(404, "Request not found"));

            if (request.Status != AdoptionStatusEnum.Pending)
                return BadRequest(new ApiResponse(400, "Request already processed"));

            request.Status = AdoptionStatusEnum.Aprroved;


            await _adoptionRepo.UpdateAsync(request);
            var animal = await _animalrep.GetById(request.AnimalId);

            if (animal != null)
            {
                animal.IsAdopted = true;
                await _animalrep.UpdateAsync(animal);
            }
            return Ok(new ApiResponse(200, "Request accepted successfully"));

        }



        [HttpPut("RejectRequest/{id}")]
        public async Task<IActionResult> RejectAdoption(int id)
        {
            var request = await _adoptionRepo.GetById(id);

            if (request == null)
                return NotFound(new ApiResponse(404, "Request not found"));

            if (request.Status != AdoptionStatusEnum.Pending)
                return BadRequest(new ApiResponse(400, "Request already processed"));

            request.Status = AdoptionStatusEnum.Rejected;

            await _adoptionRepo.UpdateAsync(request);

            return Ok(new ApiResponse(200, "Request rejected successfully"));
        }

        [HttpPost("AnimalAdd")]
        public async Task<IActionResult> AddAnimal(CreateAnimalDTO animal)
        {
            var newAnimal = new Animal
            {
                Name = animal.Name,
                Age = animal.Age,
                Gender = animal.Gender,
                HealthStatus = animal.HealthStatus,
                ShelterId = animal.ShelterId,
                AnimalBreedId = animal.AnimalBreedId,
                AnimalTypeId = animal.AnimalTypeId,
                ImageUrl = animal.ImageUrl,
                IsAdopted = false
            };

            await _animalrep.AddAsync(newAnimal);

            return Ok(new ApiResponse(200, "Animal added successfully"));
        }




        [HttpPut("UpdateAnimalById/{id}")]
        public async Task<IActionResult> UpdateAnimal(int id, UpdateAnimalDTO animalDTO)
        {
            var UpdatedAnimal = await _animalrep.GetById(id);

            if (UpdatedAnimal == null)
                return NotFound(new ApiResponse(404, "Animal not found"));

            UpdatedAnimal.Name = animalDTO.Name;
            UpdatedAnimal.Age = animalDTO.Age;
            UpdatedAnimal.HealthStatus = animalDTO.HealthStatus;
            UpdatedAnimal.ImageUrl = animalDTO.ImageUrl;
            UpdatedAnimal.IsAdopted = animalDTO.IsAdopted;

            await _animalrep.UpdateAsync(UpdatedAnimal);

            return Ok(new ApiResponse(200, "Animal updated successfully"));
        }




        [HttpDelete("DeleteAnimalById/{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var animal = await _animalrep.GetById(id);

            if (animal == null)
                return NotFound(new ApiResponse(404, "Animal not found"));

            await _animalrep.DeleteAsync(animal);

            return Ok(new ApiResponse(200, "Animal deleted successfully"));
         }

    }
}
