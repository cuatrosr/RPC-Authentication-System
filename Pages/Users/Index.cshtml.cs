#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesUser.Models;
using RazorPagesUsers.Data;

namespace RPCAuthenticationSystem.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesUsers.Data.RazorPagesUsersContext _context;

        public IndexModel(RazorPagesUsers.Data.RazorPagesUsersContext context)
        {
            _context = context;
        }

        public IList<User> User { get; set; }

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
