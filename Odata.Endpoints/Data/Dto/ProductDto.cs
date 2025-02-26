using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Odata.Endpoints.Data.Dto
{
    public class ProductDto
    {
        public string? ProductName { get; set; }
        public long Price { get; set; }
        public int Rating { get; set; }
        public int? CategoryId { get; set; }
    }
}
