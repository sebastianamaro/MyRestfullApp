using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestfullApp.Service.Helper
{
    public class CurrencyNotFoundException : Exception
    {
        public CurrencyNotFoundException(string message) : base(message) { }
    }
}
