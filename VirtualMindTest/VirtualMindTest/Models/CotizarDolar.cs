using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using VirtualMindTest.Models;
using VirtualMindTest.Models.Interface;

namespace VirtualMindTest.Models
{
    public class CotizarDolar : ICotizar
    {
        public bool Aplicar(string moneda)
        {
            return this.GetType().Name.Equals(moneda);
        }

        public string ObtenerCotizacion()
        {
            HttpClient client = new HttpClient();
            string result = null;
            HttpResponseMessage response =  client.GetAsync("https://www.bancoprovincia.com.ar/Principal/Dolar").Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            return result;
        }
    }
}