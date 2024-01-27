using FFG.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FFG.Application.Abstractions
{
    public interface IFFGDbContext
    {
        public DbSet<CodeValue> CodeValue { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
