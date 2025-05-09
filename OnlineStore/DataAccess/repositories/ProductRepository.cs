using OnlineStore.DataAccess.Data;
using OnlineStore.DataAccess.Models;

namespace OnlineStore.DataAccess.repositories
{
    public class ProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) => _context = context;

        public List<Product> GetAllProducts() => _context.Products.ToList();
    }
}