using FFG.Application.Models;

namespace FFG.Application.Abstractions.Repositories
{
    public interface ICodeValueRepository
    {
        public Task Create(IEnumerable<CodeValue> codeValues, CancellationToken cancellationToken);
        public Task<IEnumerable<CodeValue>> GetAll(CancellationToken cancellationToken);
        public Task<IEnumerable<CodeValue>> GetAllWithFilter(string filter, CancellationToken cancellationToken);
        public void DeleteAll();
        public Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
