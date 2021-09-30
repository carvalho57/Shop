using Microsoft.Extensions.DependencyInjection;
using Shop.Application.ProductsAdmin;
using Shop.Application.Products;

namespace Shop.UI
{
    public static class ServiceRegister
    {
          public static IServiceCollection AddApplicationServices(this IServiceCollection services)
          {
              services.AddTransient<Application.ProductsAdmin.GetProduct,Application.ProductsAdmin.GetProduct>();
              services.AddTransient<Application.ProductsAdmin.GetProduct,Application.ProductsAdmin.GetProduct>();
              services.AddTransient<Application.Products.GetProducts,Application.Products.GetProducts>();
              services.AddTransient<Application.Products.GetProducts,Application.Products.GetProducts>();
              services.AddTransient<CreateProduct,CreateProduct>();
              services.AddTransient<DeleteProduct,DeleteProduct>();
              services.AddTransient<UpdateProduct,UpdateProduct>();

              return services;
          }
    }
}