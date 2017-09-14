using Data.Model;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace WebAppRest.Controllers
{
    public class PoliticaController : ApiController
    {
        readonly DatoPolitica obj = new DatoPolitica();
        /// <summary>
        /// Devuelve las politicas decuerdo al Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [AtutenticacionBaisca]
        public HttpResponseMessage Get(string id)
        {
            string autenticado = Thread.CurrentPrincipal.Identity.Name;
            try
            {
                if (autenticado == "admin")
                {
                    var data = obj.DatosPoliticaId(id);

                    if (data.Count == 0)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("No se encontró informacion para " + id));
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, data);
                    }

                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("El rol ingresado no permite ejecutar esta transaccion "));
                }

            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Error al Realizar la consulta por el id de la politica"));
            }


        }

        /// <summary>
        /// Devuelve la informacion de la polica del usuario por el nombre
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [AtutenticacionBaisca]
        public HttpResponseMessage GetPoliticaUserName(string param)
        {
            string autenticado = Thread.CurrentPrincipal.Identity.Name;
            try
            {
                if (autenticado == "admin")
                {
                    var data = obj.DatosNombreCliente(param);

                    if (data.Count == 0)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("No se encontró informacion para " + param));
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, data);
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("El rol ingresado no permite ejecutar esta transaccion "));
                }

            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Error al Realizar la consulta de las politicas de un usuario"));
            }
        }
    }
}
