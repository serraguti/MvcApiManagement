using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using MvcApiManagement.Models;
using System.Net.Http;
using System.Web;

namespace MvcApiManagement.Services
{
    public class ServiceApiHospital
    {
        private String UrlApi;
        private MediaTypeWithQualityHeaderValue Header;

        public ServiceApiHospital(string url)
        {
            this.UrlApi = url;
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Hospital>> GetHospitalesAsync() { 
            using (HttpClient client = new HttpClient())
            {
                //LAS PETICIONES API MANAGEMENT INCLUYEN
                //UN QUERYSTRING VACIO AL FINAL DE LA PETICION
                var queryString =
                    HttpUtility.ParseQueryString(string.Empty);
                var request = "/api/hospitales?" + queryString;
                //LAS PETICIONES A API MANAGEMENT NO TIENEN BASE ADDRESS
                //client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                //DEBEMOS INDICAR EN HEADERS QUE NO UTILICE CACHE
                client.DefaultRequestHeaders.CacheControl =
                    CacheControlHeaderValue.Parse("no-cache");
                //LAS PETICIONES SE REALIZAN EN EL PROPIO METODO DE LLAMADA
                //JUNTO A LA URL
                HttpResponseMessage response =
                    await client.GetAsync(this.UrlApi + request);
                if (response.IsSuccessStatusCode)
                {
                    List<Hospital> hospitales =
                        await response.Content.ReadAsAsync<List<Hospital>>();
                    return hospitales;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
