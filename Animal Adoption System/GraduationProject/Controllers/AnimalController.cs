using AutoMapper;
using Core.Entities;
using GraduationProject.DTOS;
using GraduationProject.Errors;
using GraduationProject.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Entities;
using Project.Core.Repositories;
using Project.Core.Specifications.AnimalSpec;

namespace GraduationProject.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AnimalController : BaseController
    {
        private readonly IGenericRepository<Animal> _AnimalRepo;
        private readonly IGenericRepository<AnimalBreed> _BreedRepo;
        private readonly IGenericRepository<Shelter> _shelterRepo;
        private readonly IGenericRepository<AnimalType> _TypeRepo;
        private readonly IMapper _mapper;

        public AnimalController(IGenericRepository<Animal> AnimalRepo, IMapper mapper, IGenericRepository<AnimalType> TypeRepo, IGenericRepository<AnimalBreed> BreedRepo , IGenericRepository<Shelter> shelterRepo)
        {
            _AnimalRepo = AnimalRepo;
            _mapper = mapper;
            _TypeRepo = TypeRepo;
            _BreedRepo = BreedRepo;
            _shelterRepo = shelterRepo;
        }

       

        //getall
        [HttpGet]
        public async Task<ActionResult<PaginationHandller<AnimalToReturnDTO>>> GetAnimals([FromQuery] AnimalSpecParams ? Params)
        {
            var spec = new AnimalSpec(Params);
            var animals = await _AnimalRepo.GetAllWithSpecification(spec);
            var MappedAnimals = _mapper.Map<IReadOnlyList<Animal> , IReadOnlyList<AnimalToReturnDTO>>(animals);
            var CountSpec = new AnimalFilterationCount(Params);
            var Count = await _AnimalRepo.GetCountWithSpec(CountSpec);
            return Ok(new PaginationHandller<AnimalToReturnDTO>(Params.pageSize,Params.PageIndex,MappedAnimals, Count));
        }





        //GetAllSpecid
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AnimalToReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]


        public async Task<IActionResult> GetById(int id)
        {
            var spec = new AnimalSpec(id);

            var animals = await _AnimalRepo.GetByIdWithSpec(spec);


            if (animals == null)
            {
                return NotFound(new ApiResponse(404, "animal not found"));
            }
            else
            {
                var mappedAnimalById = _mapper.Map<AnimalToReturnDTO>(animals);

                return Ok(mappedAnimalById);

            }
        }

        //get all types
        [HttpGet("Types")]

        public async Task<ActionResult<IReadOnlyList<AnimalType>>> GetTypes()
        {
            var Types = await _TypeRepo.GetAll();
            return Ok(Types);
        }

        //get all breeds
        [HttpGet("Breeds")]

        public async Task<ActionResult<IReadOnlyList<AnimalBreed>>> GetBreed()
        {
            var Breeds = await _BreedRepo.GetAll();
            return Ok(Breeds);
        }

        //get all breeds
        [HttpGet("Shelters")]

        public async Task<ActionResult<IReadOnlyList<AnimalBreed>>> GetShelter()
        {
            var shelters = await _shelterRepo.GetAll();
            return Ok(shelters);
        }




    }
}
