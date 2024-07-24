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
        Task<List<User>> GetUsersAsync();
        Task<User> AddAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<User> UpdateAsync(int id, User user);
        Task DeleteAsync(int id);
    }
}
