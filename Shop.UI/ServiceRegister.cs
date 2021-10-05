using Microsoft.Extensions.DependencyInjection;
using Shop.Application.ProductsAdmin;
using Shop.Application.Products;

namespace Shop.UI
{
    public static class ServiceRegister
    {
          public static IServiceCollection AddApplicationServices(this IServiceCollection services)
          {
              services.AddScoped<Application.ProductsAdmin.GetProduct,Application.ProductsAdmin.GetProduct>();
              services.AddScoped<Application.ProductsAdmin.GetProducts,Application.ProductsAdmin.GetProducts>();
              services.AddScoped<Application.Products.GetProducts,Application.Products.GetProducts>();
              services.AddScoped<Application.Products.GetProducts,Application.Products.GetProducts>();
              services.AddScoped<CreateProduct,CreateProduct>();
              services.AddScoped<UpdateProduct,UpdateProduct>();
              services.AddScoped<DeleteProduct,DeleteProduct>();

              return services;
          }
    }
}