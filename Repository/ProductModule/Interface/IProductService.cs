using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.ProductModule.Interface
{
    public interface IProductService
    {
        public Task<Order> AddNewProduct(Order newProduct);


        public Order GetProductById(int CustomerId);


        public Task UpdateProduct(Order productUpdate);

        public ICollection<Order> GetAll();


    }
}
