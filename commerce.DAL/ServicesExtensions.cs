using commerce.DAL.Context;
using commerce.DAL.Repository.Carts;
using commerce.DAL.Repository.Orders;
using commerce.DAL.Repository.Products;
using commerce.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.DAL
{
    public static class ServicesExtensions
    {
        public static void AddDALServices(this IServiceCollection services,
           IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("EcommerceDB");
            services.AddDbContext<EcommerceContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddScoped<IOrderRepositary, OrderRepositary>();


            services.AddScoped<ICartRepository, CartRepository>();

            services.AddScoped<IProductRepositary, ProductRepositary>();
            services.AddScoped<IUnitOfWork, ConcreteUnitOfWork>();




        }
    }
}
