using FFG.Application.Abstractions.Repositories;
using FFG.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FFG.Infrastructure.DataAccess.Repositories
{
    public class CodeValueRepository : ICodeValueRepository
    {
        private readonly FFGDbContext _dbContext;

        public CodeValueRepository(FFGDbContext dbContext)
            => _dbContext = dbContext;
        public async Task Create(IEnumerable<CodeValue> codeValues, CancellationToken cancellationToken)
        {
            await _dbContext.CodeValue.AddRangeAsync(codeValues, cancellationToken);
        }

        public async Task<IEnumerable<CodeValue>> GetAll(CancellationToken cancellationToken)
        {
            return await _dbContext.CodeValue.ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<CodeValue>> GetAllWithFilter(string filter, CancellationToken cancellationToken)
        {
            //Проверка на нужно ли query. Но думаю, что мб лучше будет разделить на два запроса, с выборкой и без.
            return await _dbContext.CodeValue.Where(codeValue => codeValue.Code == Convert.ToInt32(filter) ||
                                                                 codeValue.Value == filter).ToListAsync(cancellationToken);
        }
        public void DeleteAll()
        {
            _dbContext.CodeValue.RemoveRange(_dbContext.CodeValue);
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
