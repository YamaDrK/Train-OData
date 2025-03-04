using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Project_OData.Data;
using Project_OData.DTOs;
using Project_OData.Models;

namespace Project_OData
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services)
        {
            services.AddControllers().AddOData(options =>
                    options.Select()
                        .Filter()
                        .OrderBy()
                        .Expand()
                        .Count()
                        .SetMaxTop(null)
                        .AddRouteComponents("odata", GetEdmModel()));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }

        public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();

            return services;
        }

        public static IEdmModel GetEdmModel()
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Product>("Product");
            modelBuilder.EntityType<CreateUpdateProductDTO>();
            modelBuilder.EntityType<SubCategory>();

            return modelBuilder.GetEdmModel();
        }
    }
}
