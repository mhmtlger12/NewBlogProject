using ProgrammersBlog.Entities.Dtos.Logs;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    public interface ILogService
    {
        Task<IDataResult<LogDto>> GetAsync(Guid logId);
        Task<IDataResult<LogListDto>> GetAllAsync();
        Task<IDataResult<LogListDto>> FilterLogsAsync(string level = null, DateTime? startDate = null, DateTime? endDate = null, string userName = null);
        Task<IResult> DeleteAsync(Guid logId);
        Task<IResult> DeleteAllAsync();
        Task<IDataResult<LogListDto>> GetAllByPagingAsync(int currentPage, int pageSize,
string level, DateTime? startDate, DateTime? endDate, string userName);
        Task<IDictionary<string, int>> GetLogLevelCountsAsync();

    }
}
