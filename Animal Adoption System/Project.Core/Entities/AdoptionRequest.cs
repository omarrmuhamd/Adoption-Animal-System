using Core.Entities;
//using Project.Core.Entities.Identity;
using Project.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Entities
{
    public class AdoptionRequest : BaseEntity
    {
      //  public AppUser AppUsers { get; set; }

        public string UserId { get; set; }

        public int AnimalId { get; set; }

        public Animal Animal { get; set; }

        public AdoptionStatusEnum Status { get; set; } = AdoptionStatusEnum.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
