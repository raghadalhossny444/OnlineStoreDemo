using OnlineStore.DataAccess.repositories;
using OnlineStore.DataAccess.Models;

namespace OnlineStore.BusineesLogic.Managers
{
    public class productManager
    {
        private readonly ProductRepository _repository;

        public productManager(ProductRepository repository)
        {
            _repository = repository;
        }
        public List<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }
    }
}