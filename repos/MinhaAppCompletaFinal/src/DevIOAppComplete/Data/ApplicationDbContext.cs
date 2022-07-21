using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DevIOAppComplete.ViewModels;

namespace DevIOAppComplete.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DevIOAppComplete.ViewModels.ProdutoViewModel> ProdutoViewModel { get; set; }
        public DbSet<DevIOAppComplete.ViewModels.EnderecoViewModel> EnderecoViewModel { get; set; }
    }
}