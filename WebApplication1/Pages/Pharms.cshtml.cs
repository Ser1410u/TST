using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class PharmsModel : PageModel
    {
        private readonly ILogger<PharmsModel> _logger;
        public string RESTURL;
        public PharmsModel(ILogger<PharmsModel> logger, IConfiguration conf)
        {
            _logger = logger;
            RESTURL = conf["RESTURL"].ToString();
        }

        public void OnGet()
        {
        }
    }
}