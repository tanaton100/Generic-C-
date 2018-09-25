using Model.Models;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        bool Add(Product product);
        bool Update(Product product);
        bool Delete(Product product);
    }

    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.FindBy(id);
        }

        public bool Add(Product product)
        {
            return _productRepository.Add(product) > 0;
        }

        public bool Update(Product product)
        {
            return _productRepository.Update(product) > 0;
        }

        public bool Delete(Product product)
        {
            return _productRepository.Delete(product) > 0;
        }
    }
}