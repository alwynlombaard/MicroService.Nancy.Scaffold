using log4net.Config;
using MicroService.Nancy.IoC;
using Topshelf;
using Topshelf.Ninject;

namespace MicroService.Nancy
{
    public class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>
            {
                XmlConfigurator.Configure();
                x.UseLog4Net();
                x.UseNinject(new IocModule());

                x.Service<MicroService>(s =>
                {
                    s.ConstructUsingNinject();
                    s.WhenStarted(ls => ls.Start());
                    s.WhenStopped(ls => ls.Stop());
                });

                x.SetDescription("A micro service scaffold");
                x.SetDisplayName("Micro.Service.Scaffold");
                x.SetServiceName("Micro.Service.Scaffold");

                x.RunAsLocalSystem();
            });
        }
    }
}
