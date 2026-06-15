using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Entities
{
    public class Shelter : BaseEntity
    {

        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
    }
}
