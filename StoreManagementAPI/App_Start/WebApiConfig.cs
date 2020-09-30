using StoreManagementAPI.Models;
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
        public static IUnityContainer container = new UnityContainer();
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<ICurrencyRepository, CurrencyRepository>();
            container.RegisterType<IUnitRepository, UnitRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ICategory, Category>();
            container.RegisterType<IUnit, Unit>();
            container.RegisterType<ICurrency, Currency>();
            container.RegisterType<IProduct, Product>();


            config.DependencyResolver = new UnityResolver(container);
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
