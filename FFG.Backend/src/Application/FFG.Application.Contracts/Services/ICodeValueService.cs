using FFG.Application.Models;

namespace FFG.Application.Contracts.Services
{
    public interface ICodeValueService
    {
        public Task Create(IEnumerable<CodeValue> codeValues, CancellationToken cancellationToken);
        public Task<IEnumerable<CodeValue>> GetAllWithFilter(string? filter, CancellationToken cancellationToken);
    }
}
