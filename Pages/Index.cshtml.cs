using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesUser.Models;

namespace RPCAuthenticationSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesUsers.Data.RazorPagesUsersContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, RazorPagesUsers.Data.RazorPagesUsersContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = from m in _context.User select m;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var dbEntry = _context.User.FirstOrDefault(acc => acc.Username == Username);
            return RedirectToPage("Users/Index");
        }
    }
}