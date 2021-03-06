﻿using System;
using Model.Models;
using Model.Repositories;
using Moq;
using NUnit.Framework;
using Service.Services;

namespace UnitTest.UnitTest
{
    [TestFixture]
    public class MainProductServiceTest
    {
        private IMainProductService _mainProductService;

        [SetUp]
        public void Setup()
        {
            _mainProductService = new MainProductService();
        }

        [Test]
        public void GivenNewMainProduct_WhenAdd_ThenReturnTrue()
        {
            var mainProduct = new MainProduct
            {
                Id = 1,
                Name = "Food"
            };

            //mock
            var mockMainProductRepository = new Mock<IMainProductRepository>();
            mockMainProductRepository.Setup(method => method.Add(It.IsAny<MainProduct>())).Returns(1);
            mockMainProductRepository.Setup(method => method.FindByName(It.IsAny<String>())).Returns(() => null);

            _mainProductService = new MainProductService(mockMainProductRepository.Object);
            var result = _mainProductService.Add(mainProduct);
            Assert.IsTrue(result);

            mockMainProductRepository.Verify(method => method.Add(It.IsAny<MainProduct>()),Times.Once);
            mockMainProductRepository.Verify(method => method.FindByName(It.IsAny<string>()),Times.Once);
        }

        [Test]
        public void GivenDuplicateMainProductName_WhenAdd_ThenReturnException()
        {
            var expected = "Dupicate Add product Name";
            var mainProduct = new MainProduct
            {
                Id = 1,
                Name = "Food"
            };

            //mock
            var mockMainProductRepository = new Mock<IMainProductRepository>();
            mockMainProductRepository.Setup(method => method.Add(It.IsAny<MainProduct>())).Returns(1);
            mockMainProductRepository.Setup(method => method.FindByName(It.IsAny<string>())).Returns(() => new MainProduct { Id = 1, Name = "Food" });

            //testAssert
            _mainProductService = new MainProductService(mockMainProductRepository.Object);
            var result = Assert.Throws<Exception>(() => _mainProductService.Add(mainProduct));
            Assert.AreEqual(expected, result.Message);

            var find = _mainProductService.FindByName(mainProduct.Name);
            Assert.AreEqual(mainProduct.Name, find.Name);

            //testverrify
            mockMainProductRepository.Verify(method => method.Add(It.IsAny<MainProduct>()),Times.Never);
            mockMainProductRepository.Verify(method => method.FindByName(It.IsAny<string>()), Times.AtLeast(2));
        }

        [Test]
        public void GivenNewMainProduct_WhenUpdate_ThenReturnTrue()
        {
            var mainProduct = new MainProduct
            {
                Id = 1,
                Name = "Food"
            };

            //mockData
            var mockMainProductRepository = new Mock<IMainProductRepository>();
            mockMainProductRepository.Setup(method => method.Update(It.IsAny<MainProduct>())).Returns(1);
            mockMainProductRepository.Setup(method => method.FindByName(It.IsAny<string>())).Returns(() => null);

            //testAssert
            _mainProductService = new MainProductService(mockMainProductRepository.Object);
            var result = _mainProductService.Update(mainProduct);
            Assert.IsTrue(result);


            //testVerify
            mockMainProductRepository.Verify(method => method.Update(It.IsAny<MainProduct>()),Times.Once);
            mockMainProductRepository.Verify(method => method.FindByName(It.IsAny<string>()),Times.Once);
        }

        [Test]
        public void GivenDuplicateMainProduct_WhenUpdate_ThenReturnException()
        {
            var expected = "Dupicate Update product Name";
            var mainProduct = new MainProduct
            {
                Id = 1,
                Name = "Food"
            };

            //mockData
            var mockMainProductRepository = new Mock<IMainProductRepository>();
            mockMainProductRepository.Setup(method => method.Update(It.IsAny<MainProduct>())).Returns(1);
            mockMainProductRepository.Setup(method => method.FindByName(It.IsAny<string>())).Returns(() => new MainProduct { Id = 1, Name = "Food" });

            //test
            _mainProductService = new MainProductService(mockMainProductRepository.Object);
            var result = Assert.Throws<Exception>(() => _mainProductService.Update(mainProduct));
            Assert.AreEqual(expected, result.Message);


            mockMainProductRepository.Verify(method => method.Update(It.IsAny<MainProduct>()),Times.Never);
            mockMainProductRepository.Verify(method => method.FindByName(It.IsAny<string>()),Times.Once);
        }

        [Test]
        public void GivenIdMainProduct_WhenDelete_ThenReturnTrue()
        {
            var mainProduct = new MainProduct
            {
                Id = 5,
                Name = "Feed"
            };

            // mockData
            var mockMainProductRepository = new Mock<IMainProductRepository>();
            mockMainProductRepository.Setup(method => method.Delete(It.IsAny<MainProduct>())).Returns(1);
            mockMainProductRepository.Setup(method => method.FindById(It.IsAny<int>())).Returns(() => new MainProduct { Id = 5, Name = "Feed" });

            //test
            _mainProductService = new MainProductService(mockMainProductRepository.Object);
            var result = _mainProductService.Delete(mainProduct);
            Assert.IsTrue(result);
        

            mockMainProductRepository.Verify(method => method.FindById(It.IsAny<int>()), Times.Once);
            mockMainProductRepository.Verify(method => method.Delete(It.IsAny<MainProduct>()), Times.Once);
        }

        [Test]
        public void GivenNullIdMainProduct_WhenDelete_ThenReturnException()
        {
            var expected = "Can't FindId";
            var mainProduct = new MainProduct
            {
                Id = 0,
                Name = "joa"
            };

            // mockData
            var mockMainProductRepository = new Mock<IMainProductRepository>();
            mockMainProductRepository.Setup(method => method.Delete(It.IsAny<MainProduct>())).Returns(1);
            mockMainProductRepository.Setup(method => method.FindById(It.IsAny<int>())).Returns(() => null);

            //test
            _mainProductService = new MainProductService(mockMainProductRepository.Object);
            var result = Assert.Throws<Exception>(() => _mainProductService.Delete(mainProduct));
            Assert.AreEqual(expected, result.Message);        

            //verify
            mockMainProductRepository.Verify(method => method.Delete(It.IsAny<MainProduct>()),Times.Never);
            mockMainProductRepository.Verify(method => method.FindById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void GivenNameMainProduct_whenFindByName_ThenReturnNUll()
        {
            var mainProduct = new MainProduct
            {
                Id = 0,
                Name = "joa"
            };

            // mockData
            var mockMainProductRepository = new Mock<IMainProductRepository>();
            mockMainProductRepository.Setup(method => method.FindByName(It.IsAny<string>())).Returns(() => null);

            //test
            _mainProductService = new MainProductService(mockMainProductRepository.Object);
            var result = _mainProductService.FindByName(mainProduct.Name);
            Assert.IsNull(result);

            //verify
            mockMainProductRepository.Verify(method => method.FindByName(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void GivenNameMainProduct_whenFindByName_ThenReturnName()
        {
            var mainProduct = new MainProduct
            {
                Id = 4,
                Name = "joa"
            };

            // mockData
            var mockMainProductRepository = new Mock<IMainProductRepository>();
            mockMainProductRepository.Setup(method => method.FindByName(It.IsAny<string>())).Returns(() => new MainProduct
            {
                Id = 4,
                Name = "joa"
            } );

            //test
            _mainProductService = new MainProductService(mockMainProductRepository.Object);// ใส่พารามิเตอ mockข้อมูล
            var result = _mainProductService.FindByName(mainProduct.Name);
            Assert.AreEqual(mainProduct.Name, result.Name);

            //verify
            mockMainProductRepository.Verify(method => method.FindByName(It.IsAny<string>()), Times.Once);
        }

        [TearDown]
        public void TearDown()
        {
            _mainProductService = null;
        }
    }
}