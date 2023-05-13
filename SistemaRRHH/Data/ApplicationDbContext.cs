using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaRRHH.Models;

namespace SistemaRRHH.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SistemaRRHH.Models.Worker>? Worker { get; set; }
        public DbSet<SistemaRRHH.Models.Family>? Family { get; set; }
    }
}