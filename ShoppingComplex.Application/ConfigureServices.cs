using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Application.Services;

namespace ShoppingComplex.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<ILeaseAgreementService, LeaseAgreementService>();
            services.AddScoped<ILeasePaymentService, LeasePaymentService>();
            services.AddScoped<IMaintenanceContractService, MaintenanceContractService>();
            services.AddScoped<IMaintenancePaymentService, MaintenancePaymentService>();
            services.AddScoped<IFinancialReportService, FinancialReportService>();

            return services;
        }
    }
}