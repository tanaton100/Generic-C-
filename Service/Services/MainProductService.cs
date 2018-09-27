using System;
using System.Collections.Generic;
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

        public MainProductService(IMainProductRepository mainProductRepository)
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
            var result = false;
            var mainproduct = FindByName(mainProduct.Name);
            if (mainproduct == null)
            {
                result = _mainProductRepository.Update(mainProduct) > 0;
            }
            else
            {
                throw new Exception("Dupicate Update product Name");
            }
            return result;
        }

        public bool Detele(MainProduct mainProduct)
        {
            var result = false;
            var mainproduct = FindById(mainProduct.Id);
            if (mainproduct == null)
            {
                throw new Exception("Can't FindId");
            }
            else
            {
                result = _mainProductRepository.Delete(mainProduct) > 0;
            }
            return result;
        }

        public MainProduct FindByName(string name)
        {   
            return _mainProductRepository.FindByName(name);
        }

    }
}