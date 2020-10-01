using StoreManagementAPI.Models;
using StoreManagementAPI.Models.BusinessLayer;
using StoreSchema;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace StoreManagementAPI
{
    public static class UnityConfig
    {
        public static IUnityContainer container = new UnityContainer();
        public static void RegisterComponents()
        {
            //var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //container.RegisterType<ICategoryRepository, CategoryRepository>();
            //container.RegisterType<ICurrencyRepository, CurrencyRepository>();
            //container.RegisterType<IUnitRepository, UnitRepository>();
            //container.RegisterType<ICategoryRepository, ProductRepository>(); 
            //container.RegisterType<ICategory, Category>();
            //container.RegisterType<IUnit, Unit>();
            //container.RegisterType<ICurrency, Currency>();
            //container.RegisterType<ICategory, Product>();


            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<ICurrencyRepository, CurrencyRepository>();
            container.RegisterType<IUnitRepository, UnitRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}