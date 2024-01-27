using FFG.Application.Abstractions.Repositories;
using FFG.Application.Contracts.Services;
using FFG.Application.Models;

namespace FFG.Application.Services
{
    public class CodeValueService : ICodeValueService
    {
        private readonly ICodeValueRepository _codeValueRepository;

        public CodeValueService(ICodeValueRepository codeValueRepository)
            => _codeValueRepository = codeValueRepository;
        public async Task Create(IEnumerable<CodeValue> codeValues, CancellationToken cancellationToken)
        {
            codeValues.OrderBy(codeValue => codeValue.Code);

            // TODO: Проверка на количество, надо ли удалять
            _codeValueRepository.DeleteAll();
            await _codeValueRepository.Create(codeValues, cancellationToken);
            await _codeValueRepository.SaveChangesAsync(cancellationToken);
        }
        public Task<IEnumerable<CodeValue>> GetAllWithFilter(string? filter, CancellationToken cancellationToken)
            => filter == null ? _codeValueRepository.GetAll(cancellationToken) : _codeValueRepository.GetAllWithFilter(filter, cancellationToken);
    }
}
