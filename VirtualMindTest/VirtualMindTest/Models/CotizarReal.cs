using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualMindTest.Models.Interface;

namespace VirtualMindTest.Models
{
    public class CotizarReal : ICotizar
    {
        public bool Aplicar(string moneda)
        {
            return this.GetType().Name.Equals(moneda);
        }

        public string ObtenerCotizacion()
        {
            return null;
        }
    }
}