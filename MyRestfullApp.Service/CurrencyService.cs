using MyRestfullApp.Service.Helper;
using MyRestfullApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestfullApp.Service
{
    public class CurrencyService : ICurrencyService
    {
        public double GetCurrency(string currency)
        {
            ICurrencyCalculator calculator;
            switch (currency.ToUpper())
            {
                case "DOLAR":
                    calculator = new DolarCalculator();
                    break;
                case "PESO":
                    calculator = new PesoCalculator();
                    break;
                case "REAL":
                    calculator = new RealCalculator();
                    break;

                default:
                    throw new CurrencyNotFoundException("Currency not supported");
            }

            return new CurrencyCalculator(calculator).GetCurrency();
        }
    }
}
