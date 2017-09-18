using System;
using System.Reflection;
using System.Web;
using Funq;
using Ninject;
using ServiceStack;
using ServiceStack.Api.Swagger;

namespace FinancialControl.Service
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();
        }

        internal class AppHost : AppHostBase
        {
            public AppHost() : base("Services",
                Assembly.GetExecutingAssembly()
            )
            {
            }


            public override void Configure(Container container)
            {
                Plugins.Add(new SwaggerFeature());
                var kernel = new StandardKernel();
                var cont = new IocContainer(kernel);
                cont.Load();
                container.Adapter = cont;

            }
        }
    }
}