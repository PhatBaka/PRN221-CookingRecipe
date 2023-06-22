using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Repository.ProductModule.Interface;
using DataAccess.Models;

namespace Repository.ProductModule
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Order> AddNewProduct(Order newProduct)
        {
            newProduct.OrderId = _productRepository.GetMaxID();
            await _productRepository.AddAsync(newProduct);
            return  GetProductById(newProduct.OrderId);
        }

        public Order GetProductById(int CustomerId)
        {
            return _productRepository.GetFirstOrDefaultAsync(x => x.CustomerId.Equals(CustomerId)).Result;
        }

        public async Task UpdateProduct(Order productUpdate)
        {
            await _productRepository.UpdateAsync(productUpdate);
        }

        public ICollection<Order> GetAll()
        {
            ICollection<Order> products =  _productRepository.GetAll();
            return products;
        }

    }
}
