using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortLink.Client.Data.ViewModels;
using ShortLink.Data;
using ShortLink.Data.Models;
using ShortLink.Data.Sevices;

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
            //fake data
            var allUrls = await _urlsService.GetUrlsAsync();
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
