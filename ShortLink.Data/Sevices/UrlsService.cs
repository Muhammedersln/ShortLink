﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Data.Sevices
{
    public class UrlsService
    {
        private AppDbContext _context;
        public UrlsService(AppDbContext context)
        {
            _context = context;
        }
    }
}
