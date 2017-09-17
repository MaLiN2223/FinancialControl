using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using FinancialControl.Database;
using Funq;
using ServiceStack;
using ServiceStack.Api.Swagger;
using ServiceStack.Host;

namespace FinancialControl.Service
{

    public class Global : HttpApplication
    {
        public class AppHost : AppHostBase
        {
            public AppHost() : base("Services",
                typeof(FinancialControlService).Assembly
                )
            { }


            public override void Configure(Funq.Container container)
            {

                Plugins.Add(new SwaggerFeature());
            }
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();
        }
    }
}