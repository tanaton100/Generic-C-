using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model.Models;
using Service.Services;

namespace WebApi.Controllers
{
    [RoutePrefix("api/MainProducts")]
    public class MainProductController : ApiController
    {
        private IMainProductService _mainProductService;

        public MainProductController()
        {
            _mainProductService = new MainProductService();
        }

        // GET: api/MainProduct
        [HttpGet]
        public IEnumerable<MainProduct> GetAll()
        {
            return _mainProductService.GetAll();
        }

        [HttpGet]
        [Route("{name}")]
        public MainProduct GetByName(string name)
        {
            return _mainProductService.FindByName(name);
        }

        // GET: api/MainProduct/5
        [HttpGet]
        [Route("{id:int}")]
        public MainProduct GetId(int id)
        {
            return _mainProductService.FindById(id);
        }

        // POST: api/MainProduct
        [HttpPost]
        public bool Post(MainProduct mainProduct)
        {
            return _mainProductService.Add(mainProduct);
        }

        // PUT: api/MainProduct/5
        [HttpPut]
        public bool Put(MainProduct mainProduct)
        {
            return _mainProductService.Update(mainProduct);
        }

        // DELETE: api/MainProduct/5
        [HttpDelete]
        [Route("{id:int}")]
        public bool Delete(int id)
        {
            var mainProduct = new MainProduct {Id = id};
            return _mainProductService.Detele(mainProduct);
        }
    }
}
