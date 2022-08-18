using DependencyInversioon.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using DependencyInversioon.Models;

namespace DependencyInversioon.Controllers
{
    public class AuthController : ApiController
    {

        [BasicAuthentication]
        public HttpResponseMessage Get(string gender = "All")
        {
            string username = Thread.CurrentPrincipal.Identity.Name;

            using (uttaraon_neerajEntities1 entities = new uttaraon_neerajEntities1())
            {
                switch (username.ToLower())
                {
                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Employees.Where(e => e.Gender.ToLower() == "male").ToList());
                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Employees.Where(e => e.Gender.ToLower() == "female").ToList());
                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
        }

    }
}
