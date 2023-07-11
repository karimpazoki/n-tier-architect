using FoodParty.DomainLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FoodParty.PresentationLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly AppSetting configOption;
        public HomeController(IOptions<AppSetting> options)
        {
            configOption = options.Value;
        }
        [HttpGet]
        public string Get()
        {
            return "aa";
        }
    }
}
