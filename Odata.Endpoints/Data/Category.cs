using System.ComponentModel.DataAnnotations;

namespace Odata.Endpoints.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> products { get; set; }
    }
}
