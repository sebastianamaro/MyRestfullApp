using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRestfullApp.Service.Helper
{
    public class RealCalculator : ICurrencyCalculator
    {
        public double GetCurrency()
        {
            throw new CurrencyNotImplementedException();
        }
    }
}