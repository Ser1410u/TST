using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class StoresModel : PageModel
    {
        private readonly ILogger<StoresModel> _logger;
        public string RESTURL;
        public StoresModel(ILogger<StoresModel> logger, IConfiguration conf)
        {
            _logger = logger;
            RESTURL = conf["RESTURL"].ToString();
        }

        public void OnGet()
        {
        }
    }
}