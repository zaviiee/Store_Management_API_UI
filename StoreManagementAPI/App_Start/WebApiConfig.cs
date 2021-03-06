﻿using StoreManagementAPI.Models;
using StoreManagementAPI.Models.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using StoreSchema;

namespace StoreManagementAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services



            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            config.DependencyResolver = new UnityResolver(UnityConfig.container);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
