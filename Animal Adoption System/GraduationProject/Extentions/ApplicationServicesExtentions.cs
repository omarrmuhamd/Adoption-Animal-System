using GraduationProject.Errors;
using GraduationProject.Helper;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Repositories;
using Project.Repository;

namespace GraduationProject.Extentions
{
    public static class ApplicationServicesExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services )
        {
            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            Services.AddAutoMapper(m => m.AddProfile(new MappingProfiles())); 
            Services.AddScoped<AnimalPictureUrlResolver>();


            Services.Configure<ApiBehaviorOptions>(Options =>
            {
                Options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(p => p.Value.Errors.Count > 0).
                    SelectMany(p => p.Value.Errors).
                    Select(e => e.ErrorMessage).
                    ToList();
                    var ValidationErrorResponse = new ApiValidationErrorsResponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(ValidationErrorResponse);

                };

            });
            return Services;


        }

    }
}
