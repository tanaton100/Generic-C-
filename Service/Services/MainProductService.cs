using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Models;
using Model.Repositories;

namespace Service.Services
{
    public interface IMainProductService
    {
        IEnumerable<MainProduct> GetAll();
        MainProduct FindById(int id);
        bool Add(MainProduct mainProduct);
        bool Update(MainProduct mainProduct);
        bool Detele(MainProduct mainProduct);
        MainProduct FindByName(string name);
    }

    public class MainProductService : IMainProductService
    {
        private IMainProductRepository _mainProductRepository;

        public MainProductService()
        {
            _mainProductRepository =  new MainProductRepository();
        }

        public MainProductService(MainProductRepository mainProductRepository)
        {
            _mainProductRepository = mainProductRepository;
        }

        public IEnumerable<MainProduct> GetAll()
        {
            return _mainProductRepository.GetAll();
        }

        public MainProduct FindById( int id)
        {
            return _mainProductRepository.FindBy(id);
        }

        public bool Add(MainProduct mainProduct)
        {
            var result = false;
            var mainproduct = FindByName(mainProduct.Name);
            if (mainproduct == null)
            {
                result  = _mainProductRepository.Add(mainProduct) > 0;
            }

            else
            {
                throw new Exception("Dupicate Add product Name");
            }  
            
            return result;
        }

        public bool Update(MainProduct mainProduct)
        {
            return _mainProductRepository.Update(mainProduct) > 0;
        }

        public bool Detele(MainProduct mainProduct)
        {
            return _mainProductRepository.Delete(mainProduct) > 0;
        }

        public MainProduct FindByName(string name)
        {
            
            return _mainProductRepository.FindByName(name);
        }

    }
}