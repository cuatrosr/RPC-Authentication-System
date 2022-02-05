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

        [BindProperty]
        public string SearchUsername { get; set; }

        [BindProperty]
        public string SearchPassword { get; set; }


        public new IList<User> User { get; set; }

        public async Task OnGetAsync()
        {
            var TotalUsers = from m in _context.User
                             select m;
            var user = TotalUsers;
            if (!string.IsNullOrEmpty(SearchUsername))
            {
                user = TotalUsers.Where(s => s.Username.Equals(SearchUsername));
            }
            User = await user.ToListAsync();
            if (User.Count == 1)
            {
                if (User.ElementAt(0).Password.Equals(SearchPassword) && !string.IsNullOrEmpty(SearchPassword))
                {
                    ViewData["Message"] = User.ElementAt(0).Username;
                    User = await TotalUsers.ToListAsync();
                }
                else
                {
                    Response.Redirect("../Index");
                }
            }
            else
            {
                Response.Redirect("../Index");
            }
        }
    }
}
