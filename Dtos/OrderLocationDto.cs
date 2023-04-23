

namespace Dtos
{
    public class OrderLocationDto
    {
        public int OrderId { get; set; }
        public List<ProductLocationDto>? Products { get; set; } = new List<ProductLocationDto>();
    }
}
