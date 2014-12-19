using System;
using System.Configuration;
using log4net;
using Microsoft.Owin.Hosting;

namespace MicroService.Nancy
{
    public class MicroService
    {
        private readonly ILog _log;
        private IDisposable _app;

        public MicroService(ILog log)
        {
            _log = log;
        }

        public void Start()
        {
            _log.Info("Starting Web pipeline...");
            var port = ConfigurationManager.AppSettings["Port"];
            _app = WebApp.Start<WebPipeline>("http://+:" + port);
            _log.InfoFormat("Web pipeline started. Listening on port {0}", port);

        }

        public void Stop()
        {
            _log.Info("Stopping Web pipeline...");
            _app.Dispose();
            _log.Info("Web pipeline stopped.");

        }
    }
}
