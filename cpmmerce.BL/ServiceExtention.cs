using commerce.BL.Manger.Cart;
using commerce.BL.Manger.Order;
using commerce.BL.Manger.Product;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.BL
{
    public  static class ServiceExtention
    { 
   public static void AddBLServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderManeger, OrderManeger>();


        services.AddScoped<IProductManeger, ProductManeger>();

        services.AddScoped<ICartManeger, CartManeger>();

    }
}


}
