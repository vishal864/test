﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Newspaper.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{category}"
                //defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "CategoryAPI",
            //    routeTemplate: "api/{controller}/{category}"
            //);
        }
    }
}
