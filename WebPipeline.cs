using System;
using log4net;
using Ninject.Web.Common.OwinHost;
using Owin;
using Topshelf.Ninject;

namespace MicroService.Nancy
{
    public class WebPipeline
    {
        public void Configuration(IAppBuilder application)
        {
            try
            {
                var kernel = NinjectBuilderConfigurator.Kernel;
                application.UseNancy();
                application.UseNinjectMiddleware(() => kernel);
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("Default").Error("Unhandled Exception occured.", ex);
                throw;
            }
        }
    }
}
