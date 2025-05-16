using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Concrete.EntityFramework;


namespace ProgrammersBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfLogRepository : EfEntityRepositoryBase<Log>, ILogRepository
    {
        public EfLogRepository(DbContext context) : base(context)
        {
        }

        public async Task DeleteAllAsync()
        {
            // Tüm log kayıtlarını silmek için
            var logs = await _context.Set<Log>().ToListAsync();
            _context.Set<Log>().RemoveRange(logs);
        }
         public IQueryable<Log> GetAsQueryable()
        {
            return _context.Set<Log>().AsQueryable();
        }
    }
}