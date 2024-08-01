using ShortLink.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Data.Sevices
{
    public interface IUsersService
    {
        Task<List<AppUser>> GetUsersAsync();

    }
}
