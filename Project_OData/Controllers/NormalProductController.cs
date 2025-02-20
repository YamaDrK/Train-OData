using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_OData.Data;

namespace Project_OData.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class NormalProductController(ApplicationDbContext _dbContext) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Products);
        }
    }
}
