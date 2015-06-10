using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;

namespace Other.DebuggingExternalSourceCode.Controllers
{
    public class HomeController:Controller
    {
        private IOptions<LoggingConfiguration> _loggingConfig;
        private IOptions<AppSettings> _appSettings; 
        public HomeController(IOptions<LoggingConfiguration> loggingConfig, IOptions<AppSettings> appSettings)
        {
            this._loggingConfig = loggingConfig;
            this._appSettings = appSettings;
        }

        public IActionResult Index()
        {
            string siteName = _appSettings.Options.SiteTitle;
            return View();
        }
    }
}
