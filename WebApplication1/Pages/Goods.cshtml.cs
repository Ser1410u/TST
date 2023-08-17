using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class GoodsModel : PageModel
    {
        private readonly ILogger<GoodsModel> _logger;
        public GoodsModel(ILogger<GoodsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}