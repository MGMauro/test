using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using VirtualMindTest.Models;

namespace VirtualMindTest.Models.Interface
{
    public interface ICotizar
    {
        string ObtenerCotizacion();
        bool Aplicar(string moneda);
    }
}
