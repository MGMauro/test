using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualMindTest.Models.Interface;

namespace VirtualMindTest.Models
{
    public class CotizarStrategy : ICotizarStrategy
    {

        private readonly ICotizar[] monedas;

        public CotizarStrategy(ICotizar[] monedas)
        {
            this.monedas = monedas ?? throw new ArgumentNullException("monedas");
        }

        public string ObtenerCotizacion(string nombreMoneda)
        {
            var moneda = monedas
                .FirstOrDefault(x => x.Aplicar(nombreMoneda));

            return moneda.ObtenerCotizacion();
        }
       
        
    }
}
