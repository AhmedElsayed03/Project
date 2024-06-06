using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Application.Abstractions.Repositories;
using Project.Application.Abstractions.Services;
using Project.Application.Abstractions.UnitOfWork;
using Project.Infrastructure.Data.Context;
using Project.Infrastructure.Data.Repositories;
using Project.Infrastructure.Data.UnitOfWork;
using Project.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Context
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MarketDbContext>(options =>
                options.UseSqlServer(connectionString));
            #endregion


            #region Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClientRepo, ClientRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IClientProductRepo, ClientProductRepo>();
            #endregion


            #region Services
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IClientProductService, ClientProductService>();
            #endregion

            return services;
        }
    }
}
