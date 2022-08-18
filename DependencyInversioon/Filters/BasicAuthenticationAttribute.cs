using DependencyInversioon.Security;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DependencyInversioon.Filters
{
    public class BasicAuthenticationAttribute:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null) //when no header is supplied
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
            else     //when header is supplied
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;    //receice the encoded text like bWFsZTptYWxl for malle:male(username:password)
                             
                string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken)); //decode bWFsZTptYWxl      
                string[] usernamePasswordArray = decodedAuthenticationToken.Split(':'); // split bWFsZTptYWxl  separated by :
                string username = usernamePasswordArray[0];      //male
                string password = usernamePasswordArray[1];      //male

                if (EmployeeSecurity.Login(username, password))  //call this function in security class
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null); //null can be changed by role    idedntity will be created as per username
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}