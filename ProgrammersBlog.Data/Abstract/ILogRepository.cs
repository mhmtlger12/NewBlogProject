using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos.Logs;
using ProgrammersBlog.Shared.Data.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;


namespace ProgrammersBlog.Data.Abstract
{
    public interface ILogRepository : IEntityRepository<Log>
    {
        // Tüm logları silmek için özel metot
        Task DeleteAllAsync();
        IQueryable<Log> GetAsQueryable();

    }
}
