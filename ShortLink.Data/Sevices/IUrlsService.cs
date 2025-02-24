﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortLink.Data.Models;

namespace ShortLink.Data.Sevices
{
    public interface IUrlsService
    {
        Task<List<Url>> GetUrlsAsync(string userId, bool isAdmin);
        Task<Url> AddAsync(Url url);
        Task<Url> GetByIdAsync(int id);
        Task<Url> UpdateAsync(int id, Url url);
        Task DeleteAsync(int id);

        Task<Url> GetOriginalUrlAsync (string shortUrl);
        Task IncrementNumberOfClicksAsync(int shortUrlId);
    }
}
