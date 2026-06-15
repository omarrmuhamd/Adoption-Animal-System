using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Data.Configrations
{
    public class AnimalConfigration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasOne(a => a.Shelter)
             .WithMany();

            builder.HasOne(a => a.AnimalType)
                   .WithMany();

            builder.HasOne(a => a.AnimalBreed)
                   .WithMany();

        }
    }
}
