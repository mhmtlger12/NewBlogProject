using AutoMapper;
using ProgrammersBlog.Entities.Dtos.Articles;
using ProgrammersBlog.Mvc.Areas.Admin.Models;

namespace ProgrammersBlog.Mvc.AutoMapper.Profiles
{
    public class ArticleViewModelProfile : Profile
    {
        public ArticleViewModelProfile()
        {
            // View Model Mappings
            CreateMap<ArticleAddViewModel, ArticleAddDto>();
            CreateMap<ArticleUpdateViewModel, ArticleUpdateDto>();
            CreateMap<ArticleUpdateDto, ArticleUpdateViewModel>();
        }
    }
}
