using Domain.Models.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class TireDto
    {
        public required string TireModel { get; set; }
        public Brand Brand { get; set; }

        public required string TireSize { get; set; }
        public required decimal TireTreadDepth { get; set; }
    }
}
