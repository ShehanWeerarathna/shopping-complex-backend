using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingComplex.Infrastructure.Data;
using ShoppingComplex.Infrastructure.Repositories;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;

namespace ShoppingComplex.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<ILeaseAgreementRepository, LeaseAgreementRepository>();
            services.AddScoped<ILeasePaymentRepository, LeasePaymentRepository>();

            
            return services;
        }
    }
}