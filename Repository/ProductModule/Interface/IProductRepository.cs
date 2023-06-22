using DataAccess.Models;
using Repository.Utils.BakeryRepository.Interface;

namespace Repository.ProductModule.Interface
{
    public interface IProductRepository : IRepository<Order>
    {
        public int GetMaxID();
    }
}
