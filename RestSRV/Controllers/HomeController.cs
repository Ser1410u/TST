using Microsoft.AspNetCore.Mvc;
using RestSRV.Classes;

namespace RestSRV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _conf;
        public HomeController(ILogger<HomeController> logger, IConfiguration conf)
        {
            _logger = logger;
            _conf = conf;
        }

        [HttpGet]
        [HttpPost]
        public string Get()
        {
            try
            {
                Response.StatusCode = _conf["AlertString"] == null?200:500;
                return (_conf["AlertString"] ?? "OK").ToString();
            }
            catch (Exception )
            {
                this.Response.StatusCode = 500;
                return "Служба недоступна";
            }
        }
    }
}