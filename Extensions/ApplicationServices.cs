using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingBack.Interfaces;
using DatingBack.Services;
using DatingProject.Data;
using Microsoft.EntityFrameworkCore;

namespace DatingBack.Extensions
{
    public static class ApplicationServiceExtensions
    {
      public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
      {
        services.AddDbContext<DataContext>(options =>
        {
          options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors();
        services.AddScoped<ITokenService, TokenServices>();

        return services;
      }  
    }
}