using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Dtos.Logs;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Concrete
{
    public class LogService : ILogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<LogDto>> GetAsync(Guid logId)
        {
            var log = await _unitOfWork.Logs.GetAsync(l => l.Id == logId);
            if (log != null)
            {
                return new DataResult<LogDto>(ResultStatus.Success, new LogDto
                {
                    Log = log
                });
            }
            return new DataResult<LogDto>(ResultStatus.Error, "Böyle bir log kaydı bulunamadı.", null);
        }

        public async Task<IDataResult<LogListDto>> GetAllAsync()
        {
            var logs = await _unitOfWork.Logs.GetAllAsync();
            if (logs.Any())
            {
                return new DataResult<LogListDto>(ResultStatus.Success, new LogListDto
                {
                    Logs = logs
                });
            }
            return new DataResult<LogListDto>(ResultStatus.Error, "Hiç log kaydı bulunamadı.", null);
        }

        public async Task<IDataResult<LogListDto>> FilterLogsAsync(string level = null, DateTime? startDate = null, DateTime? endDate = null, string userName = null)
        {
            // Tüm logları çek ve filtreleme işlemlerini yap
            var query = _unitOfWork.Logs.GetAsQueryable();

            // Log seviyesine göre filtrele
            if (!string.IsNullOrEmpty(level))
            {
                query = query.Where(l => l.Level == level);
            }

            // Başlangıç tarihine göre filtrele
            if (startDate.HasValue)
            {
                query = query.Where(l => l.Logged >= startDate.Value);
            }

            // Bitiş tarihine göre filtrele
            if (endDate.HasValue)
            {
                // Bitiş tarihinin sonuna kadar almak için
                endDate = endDate.Value.AddDays(1).AddSeconds(-1);
                query = query.Where(l => l.Logged <= endDate.Value);
            }

            // Kullanıcı adına göre filtrele
            if (!string.IsNullOrEmpty(userName))
            {
                query = query.Where(l => l.UserName.Contains(userName));
            }

            // Sonuçları tarihe göre sırala (en yeni üstte)
            query = query.OrderByDescending(l => l.Logged);

            // Sonuçları al
            var logs = await query.ToListAsync();

            if (logs.Any())
            {
                return new DataResult<LogListDto>(ResultStatus.Success, new LogListDto
                {
                    Logs = logs
                });
            }
            return new DataResult<LogListDto>(ResultStatus.Error, "Filtreleme kriterlerine uygun log kaydı bulunamadı.", null);
        }

        public async Task<IResult> DeleteAsync(Guid logId)
        {
            var log = await _unitOfWork.Logs.GetAsync(l => l.Id == logId);
            if (log != null)
            {
                await _unitOfWork.Logs.DeleteAsync(log);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"ID: {logId} numaralı log başarıyla silindi.");
            }
            return new Result(ResultStatus.Error, "Böyle bir log kaydı bulunamadı.");
        }

        public async Task<IResult> DeleteAllAsync()
        {
            await _unitOfWork.Logs.DeleteAllAsync();
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, "Tüm log kayıtları başarıyla silindi.");
        }
        public async Task<IDataResult<LogListDto>> GetAllByPagingAsync(int currentPage, int pageSize,
    string level, DateTime? startDate, DateTime? endDate, string userName)
        {
            var query = _unitOfWork.Logs.GetAsQueryable();

            // Filtreleme
            if (!string.IsNullOrEmpty(level))
                query = query.Where(x => x.Level == level);

            if (startDate.HasValue)
                query = query.Where(x => x.Logged >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(x => x.Logged <= endDate.Value);

            if (!string.IsNullOrEmpty(userName))
                query = query.Where(x => x.UserName.Contains(userName));

            var totalCount = await query.CountAsync();
            var logs = await query
                .OrderByDescending(x => x.Logged)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new DataResult<LogListDto>(ResultStatus.Success, new LogListDto
            {
                Logs = logs,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = totalCount,
                Level = level,
                StartDate = startDate,
                EndDate = endDate,
                UserName = userName
            });
        }

        // LogService içine implementasyon
        public async Task<IDictionary<string, int>> GetLogLevelCountsAsync()
        {
            var logs = await _unitOfWork.Logs.GetAllAsync();
            return logs
                .GroupBy(l => l.Level)
                .OrderByDescending(g => g.Count())
                .ToDictionary(
                    g => g.Key,
                    g => g.Count()
                );
        }
    }
}
