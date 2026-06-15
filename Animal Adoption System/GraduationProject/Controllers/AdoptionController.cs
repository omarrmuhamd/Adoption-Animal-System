using AutoMapper;
using GraduationProject.DTOS;
using GraduationProject.Errors;
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
using Project.Core.Specifications.AnimalSpec;
using System.Security.Claims;

namespace GraduationProject.Controllers
{

    public class AdoptionController : BaseController
    {
        private readonly IGenericRepository<AdoptionRequest> _adoptionRepo;
        private readonly IGenericRepository<Animal> _animalRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public AdoptionController(IGenericRepository<AdoptionRequest> adoptionRepo, IGenericRepository<Animal> animalRepo, IMapper mapper, UserManager<AppUser> userManager)
        {
            _adoptionRepo = adoptionRepo;
            _animalRepo = animalRepo;
            _mapper = mapper;
            _userManager = userManager;
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpPost("Adopt")]
        public async Task<IActionResult> CreateAdoption([FromQuery] int Animalid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var animal = await _animalRepo.GetById(Animalid);
            if (animal == null)

                return NotFound(new ApiResponse(404, "Animal not found"));

            var spec = new AdoptionExistSpec(userId, Animalid);
            var existing = await _adoptionRepo.GetAllWithSpecification(spec);

            if (existing.Any())
                return BadRequest(new ApiResponse(400, "You already requested this animal"));

            var request = new AdoptionRequest
            {
                AnimalId = Animalid,
                UserId = userId,
                Status = AdoptionStatusEnum.Pending
            };

            await _adoptionRepo.AddAsync(request);

            return Ok(new ApiResponse(200, "Adoption request created successfully"));
        }





        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpGet("MyRequests")]
        public async Task<IActionResult> GetMyRequests()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new ApiResponse(401, "Invalid token"));

            var spec = new AdoptionByUserSpec(userId);
            var requests = await _adoptionRepo.GetAllWithSpecification(spec);

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




    }
}
