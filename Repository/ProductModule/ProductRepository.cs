using DataAccess.Models;
using Repository.ProductModule.Interface;
using Repository.Utils.BakeryRepository;
using System.Linq;

namespace Repository.ProductModule
{
    public class ProductRepository : Repository<Order>, IProductRepository
    {
        private readonly FUFlowerBouquetManagementContext _db;

        public ProductRepository(FUFlowerBouquetManagementContext db) : base(db)
        {
            _db = db;
        }

        public int GetMaxID()
        {
            return _db.Orders.Max(u => u.OrderId ) + 1; 
        }
    }
}
