namespace FirstWebApp.Services;

public interface IProductsRepository
{
    Task<List<Product>> GetAllProducts();
    Task<Product> AddNewProduct(Product p);
    Task<Product> Update(Product p);
}