using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using VirtualMindTest.Models;
using VirtualMindTest.Models.Interface;
using VirtualMindTest.Repository.Interface;

namespace VirtualMindTest.Controllers
{
    public class CotizarController : ApiController
    {
        private ICotizarStrategy _cotizarStrategy;
        public CotizarController(ICotizarStrategy cotizarStrategy)
        {
            _cotizarStrategy = cotizarStrategy;
        }

        // GET api/cotizar?nombreMoneda=dolar
        [ResponseType(typeof(string))]
        public IHttpActionResult Get(string nombreMoneda)
        {
            var response = _cotizarStrategy.ObtenerCotizacion($"Cotizar{char.ToUpper(nombreMoneda[0]) + nombreMoneda.Substring(1)}");
            if (response == null)
                return Unauthorized();
            else
                return Ok(response);
        }
    }
}