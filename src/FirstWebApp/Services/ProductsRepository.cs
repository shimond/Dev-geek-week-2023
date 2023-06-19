using FirstWebApp.Data;
using FirstWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApp.Services;

public class ProductsRepository : IProductsRepository
{
    private readonly CatalogDbContext _context;
    private readonly ILogger<ProductsRepository> _logger;

    public ProductsRepository(CatalogDbContext context,  ILogger<ProductsRepository> logger)
    {
        this._context = context;
        this._logger = logger;
    }

    public async Task<Product> Update(Product p)
    {
        _context.Update(p);
        await _context.SaveChangesAsync();
        return p;
    }


    public async Task<Product> AddNewProduct(Product p)
    {
        await _context.AddAsync(p);
        await _context.SaveChangesAsync();
        return p;
    }

    public async Task<List<Product>> GetAllProducts()
    {
        var result = await _context.Products.ToListAsync();
        return result;
    }
}
