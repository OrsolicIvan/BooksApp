
using Books.Data;
using Books.Interfaces;
using Books.Models;
using Books.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Books.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddScoped<ITokenService, TokenService>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DevConnection")));

            return services;
        }
    }
}
