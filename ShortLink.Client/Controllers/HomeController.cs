using Microsoft.AspNetCore.Mvc;
using ShortLink.Client.Data.ViewModels;
using ShortLink.Data;
using ShortLink.Data.Models;
using System.Diagnostics;

namespace ShortLink.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppDbContext _context;
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
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

            var newUrl = new Url ()
            {
                OriginalLink = postUrlVM.Url,
                ShortLink = GenerateShortUrl(6),
                NrOfClicks = 0,
                UserId = null,
                DateCreated = DateTime.UtcNow
            };

            _context.Urls.Add(newUrl);
            _context.SaveChanges();

            TempData["Message"] = $"Kýsaltýlmýþ Url: {newUrl.ShortLink}";

            return RedirectToAction("Index");
        }

        private string GenerateShortUrl(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            return new string(
                Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray()
                );

        }
    }
}
