using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMindTest.Models.Interface
{
    public interface ICotizarStrategy
    {
        string ObtenerCotizacion(string moneda);
    }
}
