using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesUser.Models;
using Microsoft.Extensions.Logging;

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

        [BindProperty]
        public string SearchUsername { get; set; }
        [BindProperty]
        public string SearchPassword { get; set; }

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
            var dbEntry = _context.User.FirstOrDefault(acc => acc.Username == SearchUsername);
            return RedirectToPage("Users/Index");
        }
    }
}