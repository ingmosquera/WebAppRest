using Data.Model.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;


namespace Data.Model
{
    public class DatoPolitica
    {
        
        private const string UrlAltranProducto = "http://www.mocky.io/v2/580891a4100000e8242b75c5";

        private List<Politica> ConvertJsonTolist()
        {
            var json = new WebClient().DownloadString(UrlAltranProducto);
            var listaClienes = new List<Politica>();
            dynamic JsonSereaizable = JsonConvert.DeserializeObject(json);
            var data = JsonSereaizable.policies;
            foreach (var item in data)
            {
                var Politica = new Politica()
                {
                    Id = item.id,
                    AmountInsured = item.amountInsured,
                    Email = item.email,
                    InceptionDate = item.inceptionDate,
                    InstallmentPayment = item.installmentPayment,
                    ClientId = item.clientId
                };
                listaClienes.Add(Politica);
            }
            return listaClienes;
        }

        private List<PoliticaXUsuario> ListaPoliticaPorUsuario(string name) {
                var miDato = new DatoClientes();
                var listaCliente = miDato.ConvertJsonTolist();
                var listaProducto = ConvertJsonTolist();
                var ListaPolitica = new List<PoliticaXUsuario>();
                
                foreach (var item in listaProducto)
                {
                    foreach (var valor in listaCliente)
                    {
                        if (valor.id == item.ClientId & valor.name == name)
                        {
                            var dataPoliticaXUsuario = new PoliticaXUsuario()
                            {
                                IdUsuario = item.ClientId,
                                Name = valor.name,
                                EmailUsusario = valor.email,
                                Role = valor.role,
                                IdPolitica = item.Id,
                                AmountInsured = item.AmountInsured,
                                EmailPolitica = item.Email,
                                InceptionDate = item.InceptionDate,
                                InstallmentPayment = item.InstallmentPayment
                            };
                            ListaPolitica.Add(dataPoliticaXUsuario);
                        }
                    }
                }
                return ListaPolitica;

        }


        private List<PoliticaXUsuario> ListaPoliticaId(string id)
        {
            var miDato = new DatoClientes();
            var listaCliente = miDato.ConvertJsonTolist();
            var listaProducto = ConvertJsonTolist();
            var ListaPolitica = new List<PoliticaXUsuario>();

            foreach (var item in listaProducto)
            {
                foreach (var valor in listaCliente)
                {
                    if (valor.id == item.ClientId & item.Id == id)
                    {
                        var dataPoliticaXUsuario = new PoliticaXUsuario()
                        {
                            IdUsuario = item.ClientId,
                            Name = valor.name,
                            EmailUsusario = valor.email,
                            Role = valor.role,
                            IdPolitica = item.Id,
                            AmountInsured = item.AmountInsured,
                            EmailPolitica = item.Email,
                            InceptionDate = item.InceptionDate,
                            InstallmentPayment = item.InstallmentPayment
                        };
                        ListaPolitica.Add(dataPoliticaXUsuario);
                    }
                }
            }
            return ListaPolitica;

        }



        public List<PoliticaXUsuario> DatosNombreCliente(string name)
        {
            return ListaPoliticaPorUsuario(name);
        }

        public List<PoliticaXUsuario> DatosPoliticaId(string param)
        {
            return ListaPoliticaId(param);
        }
    }
}
