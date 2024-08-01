using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortLink.Client.Data.ViewModels;
using ShortLink.Client.Helpers.Roles;
using ShortLink.Data;
using ShortLink.Data.Models;
using ShortLink.Data.Sevices;
using System.Security.Claims;

namespace ShortLink.Client.Controllers
{
    public class UrlController : Controller
    {
        private IUrlsService _urlsService;
        private readonly IMapper _mapper;


        public UrlController(IUrlsService urlsService, IMapper mapper)
        {
            _urlsService = urlsService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole(Role.Admin);

            var allUrls = await _urlsService.GetUrlsAsync(loggedInUserId,isAdmin);
            var mappedAllUrls = _mapper.Map<List<Url> ,List<GetUrlVM>>(allUrls);

            return View(mappedAllUrls);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _urlsService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
