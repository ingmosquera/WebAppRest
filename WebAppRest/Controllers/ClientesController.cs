using System.Web.Http;
using Data.Model;
using System.Net.Http;
using System.Net;
using System.Threading;
using System;

namespace WebAppRest.Controllers
{
    //[EnableCorsAttribute("*", "*", "*")]
    public class ClientesController : ApiController
    {
        readonly DatoClientes obj = new DatoClientes();
        /// <summary>
        /// Devuelve la informacion del usuario por id
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
                if (autenticado == "users" || autenticado == "admin")
                {
                    var data = obj.DatosclienteXId(id);
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
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Error al Realizar la consulta por el Id del cliente"));
            }
        }

        /// <summary>
        /// Devuelve la informacion del usuario por el nombre
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [AtutenticacionBaisca]
        public HttpResponseMessage GetName(string param)
        {
            string autenticado = Thread.CurrentPrincipal.Identity.Name;
            try
            {
                if (autenticado == "user" || autenticado == "admin")
                {
                    var data = obj.DatosclienteXNombre(param);
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
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Error al Realizar la consulta por el nombre del cliente"));
            }
            
        }
    }
}
