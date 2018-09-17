using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRestfullApp.Service;
using MyRestfullApp.Service.Helper;

namespace MyRestfullApp.Tests
{
    [TestClass]
    public class CurrencyServiceTest
    {
        [TestMethod]
        public void GetCurrencyDolar()
        {
            var value=new CurrencyService().GetCurrency("dolar");//we cannot assert a value since we are hitting the actual API. 
            Assert.AreNotEqual(0, value);
        }

        [TestMethod]
        [ExpectedException(typeof(CurrencyNotImplementedException))]
        public void GetCurrencyPeso()
        {
            var value = new CurrencyService().GetCurrency("peso");
        }

        [TestMethod]
        [ExpectedException(typeof(CurrencyNotImplementedException))]
        public void GetCurrencyReal()
        {
            var value = new CurrencyService().GetCurrency("real");
        }

        [TestMethod]
        [ExpectedException(typeof(CurrencyNotFoundException))]
        public void GetCurrencyInexistente()
        {
            var value = new CurrencyService().GetCurrency("euro");

        }
    }
}
