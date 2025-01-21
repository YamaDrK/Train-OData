using System.ComponentModel.DataAnnotations;

namespace Project_OData.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string? CategoryName { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; } = [];
    }
}
