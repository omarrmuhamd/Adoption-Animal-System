using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Specifications.AnimalSpec
{
    public class AnimalSpecParams
    {
        public string? Sort { get; set; }

        public int? BreedId { get; set; }
        public int? TypeId { get; set; }

        private int PageSize = 5;

        public int pageSize
        {
            get { return PageSize; }
            set { PageSize = value > 10 ? 10 : value; }
        }

        public int PageIndex { get; set; } = 1;

        private string? search;

        public string? AnimalNameSearch
        {
            get { return search; }
            set { search = value.ToLower(); }
        }

    }
}
