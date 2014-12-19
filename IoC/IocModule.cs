using log4net;
using Ninject.Modules;

namespace MicroService.Nancy.IoC
{
    public class IocModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().ToMethod(
               context =>
               {
                   var @type = context.Request.Target.Member.ReflectedType;
                   var name = @type == null ? "DefaultLogger" : @type.Name;
                   return LogManager.GetLogger(name);
               });

        }
    }
}
