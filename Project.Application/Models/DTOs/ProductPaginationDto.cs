using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Models.DTOs
{
    public class ProductPaginationDto
    {
        public IEnumerable<ProductReadDto> Products { get; set; }  = new List<ProductReadDto>();
        public int TotalCount { get; set; }
    }
}
