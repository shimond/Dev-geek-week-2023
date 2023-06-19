using FirstWebApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FirstWebApp.Routes;

public static class ProductsRoutes
{
    public static void AddProductsRoutes(this WebApplication app)
    {
        var productsGroup = app.MapGroup("api/products").WithTags("Products");
        
        productsGroup.MapPut("{productId}", UpdateProduct);
        productsGroup.MapGet("", GetAllProducts);
        productsGroup.MapGet("Env", GetEnv);

        productsGroup.MapPost("", AddNewProduct).RequireAuthorization();
    }

    static  Ok<OperatingSystem> GetEnv()
    {
        return TypedResults.Ok(Environment.OSVersion);
    }

    static async Task<Ok<Product>> AddNewProduct(
        IProductsRepository repository,
        IHttpContextAccessor httpContextAccessor,
        Product p)
    {
        var res = await repository.AddNewProduct(p);
        return TypedResults.Ok(res);
    }

    static async Task<Ok<List<Product>>> GetAllProducts(IProductsRepository repository)
    {
        var res = await repository.GetAllProducts();
        return TypedResults.Ok(res);
    }

    static async Task<Ok<Product>> UpdateProduct(int productId, Product p, IProductsRepository repository)
    {
        var res = await repository.Update(p with { Id = productId});
        return TypedResults.Ok(res);
    }
}
