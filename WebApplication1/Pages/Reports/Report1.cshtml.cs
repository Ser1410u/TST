using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class Reolort1Model : PageModel
    {
        public string RESTURL;
        private readonly ILogger<Reolort1Model> _logger;
        public Reolort1Model(ILogger<Reolort1Model> logger, IConfiguration conf)
        {
            _logger = logger;
            RESTURL = conf["RESTURL"].ToString();
        }

        public void OnGet()
        {
        }
    }
}