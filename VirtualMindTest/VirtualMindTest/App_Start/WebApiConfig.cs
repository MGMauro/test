using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using VirtualMindTest.Models;
using VirtualMindTest.Models.Interface;
using VirtualMindTest.Repository;
using VirtualMindTest.Repository.Interface;

namespace VirtualMindTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICotizar, CotizarDolar>("dolar");
            container.RegisterType<ICotizar, CotizarPesos>("pesos");
            container.RegisterType<ICotizar, CotizarReal>("real");

            container.RegisterType<ICotizarStrategy, CotizarStrategy>(
                new InjectionConstructor(
                    new ResolvedArrayParameter<ICotizar>(
                        new ResolvedParameter<ICotizar>("dolar"),
                        new ResolvedParameter<ICotizar>("pesos"),
                        new ResolvedParameter<ICotizar>("real"))
                        ));


            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
