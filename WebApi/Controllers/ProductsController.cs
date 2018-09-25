using Model.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        private IProductService _productService;

        public ProductsController()
        {
            _productService = new ProductService();
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetAll();
        }

        [HttpGet]
        [Route("{id:int}")]
        public Product GetById(int id)
        {
            return _productService.GetById(id);
        }

        [HttpPost]
        public bool Add(Product product)
        {
            return _productService.Add(product);
        }

        [HttpPut]
        public bool Update(Product product)
        {
            return _productService.Update(product);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public bool Delete(int id)
        {
            var product = new Product { Id = id};
            return _productService.Delete(product);
        }
    }
}
