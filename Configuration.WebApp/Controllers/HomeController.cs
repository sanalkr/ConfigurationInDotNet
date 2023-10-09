using Configuration.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Configuration.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<AppSettings> _appSettingOptions;
        private readonly IConfigurationRoot _configRoot;

        public HomeController(ILogger<HomeController> logger,
            //IConfiguration config,
            IOptions<AppSettings> appSettingOptions)
        {
            _logger = logger;
            //_configRoot = (IConfigurationRoot)config;
            _appSettingOptions = appSettingOptions;
        }

        public IActionResult Index()
        {

            //Comment out dependency injection of IConfiguration and
            //below code to access using Keys.
            //var str = $"Configuration accessed using Keys. \n" +
            //        $"ApiUrl = {_configRoot["AppSettings:ApiUrl"]} \n" +
            //        $"Hostname = {_configRoot["AppSettings:EmailConfig:Hostname"]} \n" +
            //        $"IpAddress = {_configRoot["AppSettings:IpAddress:1:Ip"]} \n" + // Index 1
            //        $"Status = {_configRoot["AppSettings:IpAddress:0:Status"]}"; // Index 0

            //Using AppSettings Option injected through dependency injection.
            var str = $"Configuration accessed using AppSettings Option. \n" +
                $"ApiUrl: {_appSettingOptions.Value.ApiUrl} " +
                $"\nHostname: {_appSettingOptions.Value.EmailConfig.Hostname} " +
                $"\nFrom: {_appSettingOptions.Value.EmailConfig.From} " +
                $"\nIpAddress Count: {_appSettingOptions.Value.IpAddress.Count()}";

            return Content(str);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}