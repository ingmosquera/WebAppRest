using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebAppRest
{
    public class AtutenticacionBaisca:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

            }
            else {
                string rol = actionContext.Request.Headers.Authorization.Parameter;
                //string decodeRol = Encoding.UTF8.GetString(Convert.FromBase64String(rol));
                var dataCliente = new DatoClientes();
                if (dataCliente.ExisteRol(rol))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(rol), null);
                }
                else {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}