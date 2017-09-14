using Data.Model.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;

namespace Data.Model
{
    public class DatoClientes
    {
        private const string UrlAltranCliente = "http://www.mocky.io/v2/5808862710000087232b75ac";

        public List<Cliente> ConvertJsonTolist() {
            var json = new WebClient().DownloadString(UrlAltranCliente);
            var listaClienes = new List<Cliente>();
            dynamic JsonSereaizable = JsonConvert.DeserializeObject(json);
            var data = JsonSereaizable.clients;
            foreach (var item in data)
            {
                var cliente = new Cliente()
                {
                    id = item.id,
                    name = item.name,
                    email = item.email,
                    role = item.role
                };
                listaClienes.Add(cliente);
            }
            return listaClienes;
        }


        public List<Cliente> DatosclienteXId(string id)
        {
            
            var ListResult = new List<Cliente>();
            ListResult.Add(ConvertJsonTolist().Find(valor => valor.id == id));

            return ListResult;
        }


        public List<Cliente> DatosclienteXNombre(string nombre)
        {
            var ListResult = new List<Cliente>();
            ListResult.Add(ConvertJsonTolist().Find(valor => valor.name == nombre));

            return ListResult;
        }

        public bool ExisteRol(string rol) {
            var resultado = ConvertJsonTolist();
            bool estado = false;
            foreach (var item in resultado)
            {
                if (item.role == rol) {
                    estado = true;
                    break;
                }
            }
            return estado;
        }

    }
}
