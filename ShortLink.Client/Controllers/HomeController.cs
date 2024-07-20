using Microsoft.AspNetCore.Mvc;
using ShortLink.Client.Data.ViewModels;
using System.Diagnostics;

namespace ShortLink.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var newUrl = new PostUrlVM();
            return View(newUrl);
        }

        public IActionResult ShortenUrl(PostUrlVM postUrlVM)
        {
            if (!ModelState.IsValid)
            {
                // Do something with the url
                return View("Index", postUrlVM);
            }
            return RedirectToAction("Index");
        }

    }
}
