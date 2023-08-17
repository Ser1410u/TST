using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class GoodsModel : PageModel
    {
        public string RESTURL;
        private readonly ILogger<GoodsModel> _logger;
        public GoodsModel(ILogger<GoodsModel> logger, IConfiguration conf)
        {
            _logger = logger;
            RESTURL = conf["RESTURL"].ToString();
        }

        public void OnGet()
        {
        }
    }
}