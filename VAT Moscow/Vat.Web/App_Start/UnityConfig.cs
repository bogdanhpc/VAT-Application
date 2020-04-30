using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;
using VAT;

namespace Vat.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            //var context1 = new VatContext();

            var context = container.RegisterType<VatContext>(TypeLifetime.Singleton);
            var c = container.Resolve<VatContext>();

            var uoc = container.RegisterType<UnityOfWork>(new InjectionConstructor(c));
            var repo = container.RegisterType<VatRepository>(new InjectionConstructor(c));

            var u = container.Resolve<UnityOfWork>();
            var r = container.Resolve<VatRepository>();


            container.RegisterType<IVatService, VatService>(new InjectionConstructor(u, r));


            //container.RegisterType<IVatService, VatService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}