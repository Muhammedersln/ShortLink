using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortLink.Client.Data.ViewModels;
using ShortLink.Data;

namespace ShortLink.Client.Controllers
{
    public class UrlController : Controller
    {
        private AppDbContext _context;

        public UrlController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //fake data
            var allUrls = _context
                .Urls
                .Include(u => u.User)
                .Select(url =>new GetUrlVM
                {
                    Id = url.Id,
                    OriginalLink = url.OriginalLink,
                    ShortLink = url.ShortLink,
                    NrOfClicks = url.NrOfClicks,
                    UserId = url.UserId,

                    User = url.User != null ? new GetUserVM
                    {
                        Id = url.User.Id,
                        FullName = url.User.FullName
                    } : null,
                })
                .ToList();
            return View(allUrls);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Remove(int id)
        {
            var url = _context.Urls.FirstOrDefault(u => u.Id == id);
            _context.Urls.Remove(url);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
