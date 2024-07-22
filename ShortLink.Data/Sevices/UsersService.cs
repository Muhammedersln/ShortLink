using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Data.Sevices
{
    public class UsersService
    {
        private AppDbContext _context;
        public UsersService(AppDbContext context)
        {
            _context = context;
        }
    }
}
