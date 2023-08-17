using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class Reolort2Model : PageModel
    {
        public string RESTURL; 
        private readonly ILogger<Reolort2Model> _logger;
        public Reolort2Model(ILogger<Reolort2Model> logger, IConfiguration conf)
        {
            _logger = logger;
            RESTURL = conf["RESTURL"].ToString();
        }

        public void OnGet()
        {
        }
    }
}