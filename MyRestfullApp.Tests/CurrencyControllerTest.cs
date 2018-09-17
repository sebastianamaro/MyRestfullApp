using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRestfullApp.Controllers;
using MyRestfullApp.Service;
using System.Web.Http;
using System.Web.Http.Results;

namespace MyRestfullApp.Tests
{
    [TestClass]
    public class CurrencyControllerTest
    {
        CotizacionController controller;
        public CurrencyControllerTest()
        {
            controller = new CotizacionController(new CurrencyService());
        }
        [TestMethod]
        public void GetCotizacionDolar()
        {
            var result = controller.Get("dolar") as OkNegotiatedContentResult<double>;
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Content);
        }

        [TestMethod]
       
        public void GetCotizacionPeso()
        {
            var result = controller.Get("peso") as UnauthorizedResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        

        public void GetCotizacionReal()
        {
            var result = controller.Get("real") as UnauthorizedResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCotizacionInexistente()
        {
            var result = controller.Get("euro") as UnauthorizedResult;
            Assert.IsNotNull(result);
        }
    }
}
