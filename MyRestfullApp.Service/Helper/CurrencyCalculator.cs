using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestfullApp.Service.Helper
{
    class CurrencyCalculator 
    {
        ICurrencyCalculator calculator;
        internal CurrencyCalculator(ICurrencyCalculator calculator)
        {
            this.calculator = calculator;
        }

        internal double GetCurrency()
        {
            return calculator.GetCurrency();
        }
    }
}
