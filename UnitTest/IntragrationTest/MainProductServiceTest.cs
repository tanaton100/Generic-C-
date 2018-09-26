using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using Model.Models;
using NUnit.Framework;
using Service.Services;


namespace UnitTest.IntragrationTest
{
    [TestFixture]
    public class MainProductServiceTest
    {
        private IMainProductService _mainProductService;
        private TransactionScope _transactionScope;
        
        [SetUp]
        public void Setup()
        {
            _mainProductService = new MainProductService();
            _transactionScope = new TransactionScope();
        }

        [Test]
        public void GivenAddNewName_WhenAdd_ThenReturnTrue()
        {
            var mainProduct = new MainProduct();
            mainProduct.Name = "Coffee";
            var result = _mainProductService.Add(mainProduct);
            Assert.IsTrue(result);        
        }

        [Test]
        public void GivenAddDuplicateName_WhenAdd_ThenReturnExceptionDuplicateName()
        {
            var mainProduct = new MainProduct();
            mainProduct.Name = "Coffee";
            Assert.DoesNotThrow(() =>_mainProductService.Add(mainProduct));
            Assert.Throws<Exception>(() => _mainProductService.Add(mainProduct));
        }

        [Test]
        public void GivenGetAll_WhenGetAll_ThenReturnList()
        {
            var mainProduct = new MainProduct();
            mainProduct.Name = "Coffee";
            Assert.DoesNotThrow(() => _mainProductService.Add(mainProduct));

            var mainProducts = _mainProductService.GetAll();
            var count = mainProducts.Count();
            Assert.Greater(count, 1);
        }

        [TearDown]
        public void TearDown()
        {
            _mainProductService = null;
            _transactionScope.Dispose();
        }
    }
}