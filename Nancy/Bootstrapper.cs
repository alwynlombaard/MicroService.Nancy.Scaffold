using System.Diagnostics;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Ninject;
using Nancy.Diagnostics;
using Ninject;
using Topshelf.Ninject;

namespace MicroService.Nancy.Nancy
{
    public class Bootstrapper : NinjectNancyBootstrapper
    {
        protected override void ApplicationStartup(IKernel container, IPipelines pipelines)
        {
            DiagnosticsHook.Disable(pipelines);

            Conventions.ViewLocationConventions.Insert(0,
                (viewName, model, context) => string.Concat("Nancy/Views/", viewName));

            EnableDebugConventions();
            StaticConfiguration.DisableErrorTraces = false;
        }

        protected override IKernel GetApplicationContainer()
        {
            NinjectBuilderConfigurator.Kernel.Load<FactoryModule>();
            return NinjectBuilderConfigurator.Kernel;
        }

        [Conditional("DEBUG")]
        private void EnableDebugConventions()
        {
            Conventions.ViewLocationConventions.Insert(0,
                (viewName, model, context) => string.Concat("../../Nancy/Views/", viewName));
        }
    }
}
