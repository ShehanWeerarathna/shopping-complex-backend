using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingComplex.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Domain
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
            return services;
        }
    }
}
