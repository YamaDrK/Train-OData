using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Project_OData.Data;
using Project_OData.Models;

namespace Project_OData
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services)
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Product>("Product");
            modelBuilder.EntityType<Inventory>();
            modelBuilder.EntityType<SubCategory>();
            modelBuilder.EntityType<Category>();

            services.AddControllers().AddOData(options =>
                    options.Select()
                        .Filter()
                        .OrderBy()
                        .Expand()
                        .Count()
                        .SetMaxTop(null)
                        .AddRouteComponents("odata", modelBuilder.GetEdmModel()));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }


        public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();

            return services;
        }
    }
}
