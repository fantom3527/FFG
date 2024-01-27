using FFG.Application.Abstractions;
using FFG.Application.Models;
using FFG.Infrastructure.DataAccess.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FFG.Infrastructure.DataAccess
{
    public class FFGDbContext : DbContext, IFFGDbContext
    {
        public DbSet<CodeValue> CodeValue { get; set; }

        public FFGDbContext(DbContextOptions<FFGDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CodeValueConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
