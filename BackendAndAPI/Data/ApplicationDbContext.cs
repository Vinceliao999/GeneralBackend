using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BackendAndAPI.Models;

namespace BackendAndAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BackendAndAPI.Models.User> User { get; set; } = default!;
        public DbSet<BackendAndAPI.Models.GetAllUsersResult> GetAllUsersResult { get; set; } = default!;
        public DbSet<BackendAndAPI.Models.Company> Company { get; set; } = default!;
    }
}
