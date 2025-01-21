using System.ComponentModel.DataAnnotations;

namespace Project_OData.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }

        public string? SubCategoryName { get; set; }

        public virtual Category? Category { get; set; }

        public virtual ICollection<Product> Products { get; set; } = [];
    }
}
