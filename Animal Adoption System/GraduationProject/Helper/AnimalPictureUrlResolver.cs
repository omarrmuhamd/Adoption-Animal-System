using AutoMapper;
using GraduationProject.DTOS;
using Project.Core.Entities;

namespace GraduationProject.Helper
{
    public class AnimalPictureUrlResolver : IValueResolver<Animal , AnimalToReturnDTO , string>

    {
        private readonly IConfiguration _configuration;

        public AnimalPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public string Resolve(Animal sourse, AnimalToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(sourse.ImageUrl))
            {
                return $"{_configuration["ApiBaseUrl"]}{sourse.ImageUrl}";
            }

            else
            {
                return string.Empty ;
            }
        }
    }
}
