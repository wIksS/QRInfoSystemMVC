﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Ninject;
using System.Web.Http;
using QRInfoSystem.Data;
using System.Reflection;

[assembly: OwinStartup(typeof(QRInfoSystem.Web.Startup))]

namespace QRInfoSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        //    app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        //}

        //private static StandardKernel CreateKernel()
        //{
        //    var kernel = new StandardKernel();
        //    kernel.Load(Assembly.GetExecutingAssembly());
        //    RegisterMappings(kernel);
        //    return kernel;
        //}

        //private static void RegisterMappings(StandardKernel kernel)
        //{
        //    kernel.Bind<IQRInfoSystemData>().To<QRInfoSystemData>();
        //}
    }
}
