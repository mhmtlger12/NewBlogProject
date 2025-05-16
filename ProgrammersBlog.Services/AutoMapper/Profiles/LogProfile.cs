using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos.Articles;
using ProgrammersBlog.Entities.Dtos.Logs;

namespace ProgrammersBlog.Services.AutoMapper.Profiles
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {

            CreateMap<Log, LogDto>();
        }
    }
}
