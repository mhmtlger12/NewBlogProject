using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace ProgrammersBlog.Entities.Dtos.Logs
{
    public class LogDto
    {
        public Log Log { get; set; }
    }

    public class LogListDto : DtoGetBase
    {
        public IList<Log> Logs { get; set; }

        // Filtreleme özellikleri
        public string Level { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UserName { get; set; }

        // Sayfalama bilgisi
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalCount / PageSize);
        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
    }
}