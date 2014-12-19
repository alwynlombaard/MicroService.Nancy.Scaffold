using System;
using log4net;
using MicroService.Nancy.Nancy.Models;
using Nancy;

namespace MicroService.Nancy.Nancy.Modules
{
    public class HomeModule : NancyModule
    {

        public HomeModule(ILog log) : base("/")
        {
           
            Get["/"] = x => { 
                log.Info("Loading home page");
                                return new HomeModel
                                {
                                    Message = "Hello world",
                                    Timestamp = DateTime.UtcNow.ToLongTimeString()
                                };
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
