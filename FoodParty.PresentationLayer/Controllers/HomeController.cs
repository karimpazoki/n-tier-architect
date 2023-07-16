using FoodParty.DomainLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FoodParty.PresentationLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly AppSetting _configOption;
        public HomeController(IOptions<AppSetting> options)
        {
            _configOption = options.Value;
        }
        [HttpGet]
        public string Get()
        {
            return "aa";
        }
    }
}
