using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestfullApp.Service.Interfaces
{
    public interface ICurrencyService
    {
        double GetCurrency(string currency);
    }
}
