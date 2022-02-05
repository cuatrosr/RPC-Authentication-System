#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesUser.Models;
using RazorPagesUsers.Data;
using Microsoft.EntityFrameworkCore;

namespace RPCAuthenticationSystem.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesUsers.Data.RazorPagesUsersContext _context;

        public string VerifyPassword { get; set; }

        public IList<User> UserList { get; set; }

        public CreateModel(RazorPagesUsers.Data.RazorPagesUsersContext context)
        {
            _context = context;
        }

        public async Task VerifyUsername()
        {
            var TotalUsers = from m in _context.User
                             select m;
            var user = TotalUsers;
            if (!string.IsNullOrEmpty(User.Username))
            {
                user = TotalUsers.Where(s => s.Username.Equals(User.Username));
            }
            UserList = await user.ToListAsync();
            if (UserList.Count == 1)
                ViewData["Message"] = "Este usuario ya existe";
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public new User User { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["Message"] = null;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (VerifyPassword.Equals(User.Password))
            {
                await VerifyUsername();
                if (ViewData["Message"] == null)
                {
                    _context.User.Add(User);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("../Index");
                }
            }
            else
                ViewData["Message"] = "La constraseña no coincide";
            return RedirectToPage("../Index");
        }
    }
}
