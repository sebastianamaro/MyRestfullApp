using MyRestfullApp.Service.Helper;
using MyRestfullApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyRestfullApp.Controllers
{
    public class CotizacionController : ApiController
    {
        ICurrencyService service;
        public CotizacionController(ICurrencyService currencyService)
        {
            this.service = currencyService;
        }
        // GET: api/Cotizacion/5
        public IHttpActionResult Get(string moneda)
        {

            try
            {
                var value = service.GetCurrency(moneda);
                return Ok(value);
            }
            catch (CurrencyNotFoundException)
            {
                return Unauthorized();
            }
            catch(CurrencyNotImplementedException)
            {
                return Unauthorized();
            }

        }
            
      
        

    }
}
