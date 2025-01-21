using System.ComponentModel.DataAnnotations;

namespace Project_OData.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public virtual Product? Product { get; set; }
    }
}
