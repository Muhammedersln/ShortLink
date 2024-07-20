using Microsoft.AspNetCore.Mvc;
using ShortLink.Client.Data.Models;
using ShortLink.Client.Data.ViewModels;

namespace ShortLink.Client.Controllers
{
    public class UrlController : Controller
    {
        public IActionResult Index()
        {
            //fake data
            var allUrls = new List<GetUrlVM>()
            {
                new GetUrlVM { Id = 1, OriginalLink = "https://www.google.com", ShortLink = "sh1",NrOfClicks=1,UserId=1 },
                new GetUrlVM { Id = 2, OriginalLink = "https://www.youtube.com", ShortLink = "sh2",NrOfClicks=5,UserId=2 },
                new GetUrlVM { Id = 3, OriginalLink = "https://www.facebbook.com", ShortLink = "sh3",NrOfClicks=9,UserId=3},
            };
            return View(allUrls);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Remove(int id)
        {
            return View();
        }
    }
}
