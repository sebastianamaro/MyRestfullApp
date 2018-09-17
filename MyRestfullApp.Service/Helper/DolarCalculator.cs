using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MyRestfullApp.Service.Helper
{
    public class DolarCalculator : ICurrencyCalculator
    {
        public double GetCurrency()
        {
            using (WebClient cli = new WebClient())
            {
                var resp = cli.DownloadString("https://www.bancoprovincia.com.ar/Principal/Dolar");

                var values =  Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(resp);

                return double.Parse(values[1], new System.Globalization.CultureInfo("en-US"));
            }

        }
    }
}