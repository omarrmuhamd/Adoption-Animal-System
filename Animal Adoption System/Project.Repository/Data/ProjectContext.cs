using Project.Core.Entities;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Data
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
            
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalBreed> AnimalBreeds { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<AdoptionRequest> AdoptionRequests { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
