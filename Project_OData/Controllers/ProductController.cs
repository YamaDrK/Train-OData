using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Project_OData.Data;

namespace Project_OData.Controllers
{
    public class ProductController(ApplicationDbContext _dbContext) : ODataController
    {
        /**
         * Basic
         * 
         * Nested include : /odata/product?$expand=subcategory($expand=category)
         * Select distinct subCategory : /odata/product?$apply=groupby((SubCategory/SubCategoryName))
         * Filter by SubCategoryName : /odata/product?$filter=SubCategory/SubCategoryName eq 'Tables'
         * Count products in each SubCategory : /odata/product?$apply=groupby((SubCategory/Id, SubCategory/SubCategoryName),aggregate(Id with countdistinct as TotalProducts))
         * Get product which not have inventories : /odata/product?$filter=Inventories/$count eq 0
         * Get product which have all inventories that greater than or equal 50 : /odata/product?$expand=Inventories&$filter=Inventories/all(i: i/Number ge 50)
         * Sort product by inventories count : /odata/product?$orderby=Inventories/$count desc&$expand=Inventories($count=true)
         */


        /**
         * Advanced
         * 
         * Sort category by products count : /odata/product?$apply=groupby((SubCategory/Id, SubCategory/SubCategoryName), aggregate(Id with countdistinct as TotalProducts))&$orderby=TotalProducts desc&$orderby=SubCategory/Id desc
         * 
         */

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_dbContext.Products);
        }

        [EnableQuery]
        public IActionResult Get([FromRoute] int key)
        {
            return Ok(_dbContext.Products.FirstOrDefault(p => p.Id == key));
        }
    }
}
