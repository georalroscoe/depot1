using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class ProductLocationDto
    {
        public int ProductId { get; set; }
        public int TotalQuantityRequired { get; set; }
    
        public List<BatchLocationDto> BatchLocations { get; set; } = new List<BatchLocationDto>();
    }
}
