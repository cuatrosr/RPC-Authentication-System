using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesUser.Models;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace RPCAuthenticationSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesUsers.Data.RazorPagesUsersContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, RazorPagesUsers.Data.RazorPagesUsersContext? context)
        {
            _logger = logger;
            _context = context;
        }

        public new IList<User> User { get; set; }
        [TempData]
        public string Message { get; set; }
        [BindProperty]
        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Required]
        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Message = null;
                return Page();
            }
            var TotalUsers = from m in _context.User select m;
            var user = TotalUsers.Where(s => s.Username.Equals(Username));
            User = await user.ToListAsync();
            if (User.Count == 1)
            {
                if (User.ElementAt(0).Password.Equals(Password))
                {
                    return RedirectToPage("Users");
                }
                Message = "La contraseña no coincide a este usuario";
            }
            else
            {
                Message = "No se han encontrado usuarios con este username";
            }
            return Page();
        }
    }
}