using Microsoft.EntityFrameworkCore;
using ShortLink.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Data.Sevices
{
    public class UrlsService : IUrlsService
    {
        private AppDbContext _context;
        public UrlsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Url> GetByIdAsync(int id)
        {
            var url = await _context.Urls.FirstOrDefaultAsync(n => n.Id == id);
            return url;
        }

        public async Task<List<Url>> GetUrlsAsync( string userId, bool isAdmin)
        {

            var allUrls =  _context.Urls.Include(n => n.User);
            
            if (isAdmin)
            {
                return await allUrls.ToListAsync();
            }
            else
            {

               return await allUrls.Where(n => n.UserId == userId).ToListAsync();
            }

        }


        public async Task<Url> AddAsync(Url url)
        {
            await _context.Urls.AddAsync(url);
            await _context.SaveChangesAsync();

            return url;
        }

        public async Task<Url> UpdateAsync(int id, Url url)
        {
            var urlDb = await _context.Urls.FirstOrDefaultAsync(n => n.Id == id);

            if (urlDb != null)
            {
                urlDb.OriginalLink = url.OriginalLink;
                urlDb.ShortLink = url.ShortLink;
                urlDb.DateUpdated = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }

            return url;
        }
        public async Task DeleteAsync(int id)
        {
            var urlDb = await _context.Urls.FirstOrDefaultAsync(n => n.Id == id);

            if (urlDb != null)
            {
                _context.Remove(urlDb);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Url> GetOriginalUrlAsync(string shortUrl)
        {
            var dbUrl = await _context.Urls.FirstOrDefaultAsync(n => n.ShortLink == shortUrl);
            return dbUrl;
        }

        public async Task IncrementNumberOfClicksAsync(int shortUrlId)
        {
            var dbUrl = await _context.Urls.FirstOrDefaultAsync(n => n.Id == shortUrlId);
            dbUrl.NrOfClicks++;
            await _context.SaveChangesAsync();
        }
    }
}
