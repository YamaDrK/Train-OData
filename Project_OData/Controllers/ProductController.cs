using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Project_OData.Data;

namespace Project_OData.Controllers
{
    public class ProductController(ApplicationDbContext _dbContext) : ODataController
    {
        [EnableQuery]
        public IActionResult Get() {
            return Ok(_dbContext.Products);
        }

        [EnableQuery]
        public IActionResult Get([FromRoute] int key)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == key);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
