using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class LotsModel : PageModel
    {
        private readonly ILogger<LotsModel> _logger;
        public string RESTURL;
        public LotsModel(ILogger<LotsModel> logger, IConfiguration conf)
        {
            _logger = logger;
            RESTURL = conf["RESTURL"].ToString();
        }

        public void OnGet()
        {
        }
    }
}