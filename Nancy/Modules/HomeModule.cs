using log4net;
using MicroService.Nancy.Nancy.Models;
using Nancy;
using System;

namespace MicroService.Nancy.Nancy.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule(ILog log)
            : base("/")
        {
            Get["/"] = x =>
            {
                log.Info("Loading home page");
                return new HomeModel
                {
                    Message = "Hello world",
                    Timestamp = DateTime.UtcNow.ToLongTimeString()
                };
            };

            Get["/Version"] = _ =>
            {
                String appName = "Microservice.Nancy"; // Pull from Assembly or Config File?

                String version = "1.0.0"; // Pull from AssemblyInfo

                String environment = "Local"; // Local/Test/Staging/Production

                return Response.AsJson(new
                {
                    Application = appName,
                    Version = version,
                    Environment = environment,
                    Server = Environment.MachineName
                });
            };

            Get["/dynamic"] = x =>
                new DynamicPageModel
                {
                    Message = "Hello world",
                    Timestamp = DateTime.UtcNow.ToLongTimeString()
                };
        }
    }
}