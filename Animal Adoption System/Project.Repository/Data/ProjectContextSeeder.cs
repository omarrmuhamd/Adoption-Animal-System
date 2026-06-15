using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project.Repository.Data
{
    public class ProjectContextSeeder
    {
        public static async Task SeedAsync(ProjectContext dbContext)
        {




            //shelter

            if (!dbContext.Shelters.Any())
            {
                var data = File.ReadAllText("../Project.Repository/Data/DataSeed/shelters.json");
                var shelters = JsonSerializer.Deserialize<List<Shelter>>(data);

                if (shelters?.Count > 0)
                {
                    foreach (var item in shelters)
                    {
                        await dbContext.Set<Shelter>().AddAsync(item);
                    }

                    await dbContext.SaveChangesAsync();
                }
            }


            //type

            if (!dbContext.AnimalTypes.Any())
            {
                var TypeData = File.ReadAllText("../Project.Repository/Data/DataSeed/types.json");
                var types = JsonSerializer.Deserialize<List<AnimalType>>(TypeData);

                if (types?.Count() > 0)
                {
                    foreach (var type in types)
                    {
                        await dbContext.Set<AnimalType>().AddAsync(type);
                    }

                    await dbContext.SaveChangesAsync();
                }

            }

            //breed

            if (!dbContext.AnimalBreeds.Any())
            {
                var data = File.ReadAllText("../Project.Repository/Data/DataSeed/breeds.json");
                var breeds = JsonSerializer.Deserialize<List<AnimalBreed>>(data);

                if (breeds?.Count > 0)
                {
                    foreach (var item in breeds)
                    {
                        await dbContext.Set<AnimalBreed>().AddAsync(item);
                    }

                    await dbContext.SaveChangesAsync();
                }
            }




            //animal

            if (!dbContext.Animals.Any())
            {
                var data = File.ReadAllText("../Project.Repository/Data/DataSeed/animals.json");
                var animals = JsonSerializer.Deserialize<List<Animal>>(data);

                if (animals?.Count > 0)
                {
                    foreach (var item in animals)
                    {
                        await dbContext.Set<Animal>().AddAsync(item);
                    }

                    await dbContext.SaveChangesAsync();
                }
            }






        }
    }
}

