#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesUser.Models;

namespace RazorPagesUsers.Data
{
    public class RazorPagesUsersContext : DbContext
    {
        public RazorPagesUsersContext (DbContextOptions<RazorPagesUsersContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesUser.Models.User> User { get; set; }
    }
}
