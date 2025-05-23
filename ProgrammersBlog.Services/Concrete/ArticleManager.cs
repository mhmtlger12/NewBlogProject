using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos.Articles;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Utilities;
using ProgrammersBlog.Shared.Entities.Concrete;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System.Linq.Expressions;


namespace ProgrammersBlog.Services.Concrete
{
    public class ArticleManager : ManagerBase, IArticleService
    {
        private readonly UserManager<User> _userManager;
        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager) : base(unitOfWork, mapper)
        {
            _userManager = userManager;
        }

        public async Task<IResult> AddAsync(ArticleAddDto articleAddDto, string createdByName, Guid UserId)
        {
            var article = Mapper.Map<ProgrammersBlog.Entities.Concrete.Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserId = UserId;
            await UnitOfWork.Articles.AddAsync(article);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, message: Messages.Article.Add(article.Title));

        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var articlesCount = await UnitOfWork.Articles.CountAsync();
            if (articlesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, articlesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, message: $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var articlesCount = await UnitOfWork.Articles.CountAsync(a => !a.IsDeleted);
            if (articlesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, articlesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, message: $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IResult> DeleteAsync(Guid articleId, string modifiedByName)
        {
            var result = await UnitOfWork.Articles.AnyAsync(a => a.Id == articleId);
            if (result)
            {
                var article = await UnitOfWork.Articles.GetAsync(a => a.Id == articleId);
                article.IsDeleted = true;
                article.IsActive = false;
                article.ModifiedByName = modifiedByName;
                article.ModifiedDate = DateTime.Now;
                await UnitOfWork.Articles.UpdateAsync(article);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, message: Messages.Article.Delete(article.Title));
            }
            return new Result(ResultStatus.Error, message: Messages.Article.NotFound(isPlural: false));
        }

        public async Task<IDataResult<ArticleDto>> GetAsync(Guid articleId)
        {
            var article = await UnitOfWork.Articles.GetAsync(a => a.Id == articleId, a => a.User, a => a.Menu);
            if (article != null)
            {
                article.Comments = await UnitOfWork.Comments.GetAllAsync(c => c.ArticleId == articleId && !c.IsDeleted && c.IsActive);
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, Messages.Article.NotFound(isPlural: false), null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllAsync()
        {
            var articles = await UnitOfWork.Articles.GetAllAsync(null, x => x.User, x => x.Menu);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, message: Messages.Article.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByMenuAsync(Guid menuId)
        {
            var result = await UnitOfWork.Menus.AnyAsync(m => m.Id == menuId);
            if (result)
            {
                var articles = await UnitOfWork.Articles.GetAllAsync(a => a.MenuId == menuId && !a.IsDeleted && a.IsActive, ar => ar.User, ar => ar.Menu);

                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success
                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, message: Messages.Article.NotFound(isPlural: true), null);
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, message: Messages.Menu.NotFound(isPlural: false), null);

        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAsync()
        {
            var articles = await UnitOfWork.Articles.GetAllAsync(x => !x.IsDeleted, a => a.User, a => a.Menu);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, message: Messages.Article.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var articles =
                await UnitOfWork.Articles.GetAllAsync(a => !a.IsDeleted && a.IsActive, ar => ar.User,
                    ar => ar.Menu);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, Messages.Article.NotFound(isPlural: true), null);

        }

        public async Task<IResult> HardDeleteAsync(Guid articleId)
        {
            var result = await UnitOfWork.Articles.AnyAsync(a => a.Id == articleId);
            if (result)
            {
                var article = await UnitOfWork.Articles.GetAsync(a => a.Id == articleId);
                await UnitOfWork.Articles.DeleteAsync(article);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, message: Messages.Article.HardDelete(article.Title));
            }
            return new Result(ResultStatus.Error, message: Messages.Article.NotFound(isPlural: false));
        }

        public async Task<IResult> UpdateAsync(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            var oldArticle = await UnitOfWork.Articles.GetAsync(a => a.Id == articleUpdateDto.Id);
            var article = Mapper.Map<ArticleUpdateDto, ProgrammersBlog.Entities.Concrete.Article>(articleUpdateDto, oldArticle);
            article.ModifiedByName = modifiedByName;
            await UnitOfWork.Articles.UpdateAsync(article);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, message: Messages.Article.Update(article.Title));

        }

        public async Task<IDataResult<ArticleUpdateDto>> GetArticleUpdateDtoAsync(Guid articleId)
        {
            var result = await UnitOfWork.Articles.AnyAsync(c => c.Id == articleId);
            if (result)
            {
                var article = await UnitOfWork.Articles.GetAsync(c => c.Id == articleId);
                var articleUpdateDto = Mapper.Map<ArticleUpdateDto>(article);
                return new DataResult<ArticleUpdateDto>(ResultStatus.Success, articleUpdateDto);
            }
            else
            {
                return new DataResult<ArticleUpdateDto>(ResultStatus.Error, message: Messages.Article.NotFound(isPlural: false), data: null);
            }
        }
        public async Task<IResult> UndoDeleteAsync(Guid articleId, string modifiedByName)
        {
            var result = await UnitOfWork.Articles.AnyAsync(a => a.Id == articleId);
            if (result)
            {
                var article = await UnitOfWork.Articles.GetAsync(a => a.Id == articleId);
                article.IsDeleted = false;
                article.IsActive = true;
                article.ModifiedByName = modifiedByName;
                article.ModifiedDate = DateTime.Now;
                await UnitOfWork.Articles.UpdateAsync(article);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Article.UndoDelete(article.Title));
            }
            return new Result(ResultStatus.Error, Messages.Article.NotFound(isPlural: false));
        }
        public async Task<IDataResult<ArticleListDto>> GetAllByDeletedAsync()
        {
            var articles =
                await UnitOfWork.Articles.GetAllAsync(a => a.IsDeleted, ar => ar.User,
                    ar => ar.Menu);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, Messages.Article.NotFound(isPlural: true), null);
        }
        //populer makaleler 
        public async Task<IDataResult<ArticleListDto>> GetAllByViewCountAsync(bool isAscending, int? takeSize)
        {
            var articles =
                await UnitOfWork.Articles.GetAllAsync(a => a.IsActive && !a.IsDeleted, a => a.Menu, a => a.User);
            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.ViewsCount)
                : articles.OrderByDescending(a => a.ViewsCount);
            return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
            {
                Articles = takeSize == null ? sortedArticles.ToList() : sortedArticles.Take(takeSize.Value).ToList()
            });
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByPagingAsync(Guid? menuId, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var articles = menuId == null
                ? await UnitOfWork.Articles.GetAllAsync(a => a.IsActive && !a.IsDeleted, a => a.Menu, a => a.User)
                : await UnitOfWork.Articles.GetAllAsync(a => a.MenuId == menuId && a.IsActive && !a.IsDeleted,
                    a => a.Menu, a => a.User);
            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.PublishDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.PublishDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
            {
                Articles = sortedArticles,
                MenuId = menuId == null ? null : menuId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            });
        }
        public async Task<IDataResult<ArticleListDto>> SearchAsync(string keyword, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            if (string.IsNullOrWhiteSpace(keyword))
            {
                var articles =
                    await UnitOfWork.Articles.GetAllAsync(a => a.IsActive && !a.IsDeleted, a => a.Menu,
                        a => a.User);
                var sortedArticles = isAscending
                    ? articles.OrderBy(a => a.PublishDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                    : articles.OrderByDescending(a => a.PublishDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = sortedArticles,
                    CurrentPage = currentPage,
                    PageSize = pageSize,
                    TotalCount = articles.Count,
                    IsAscending = isAscending
                });
            }

            var searchedArticles = await UnitOfWork.Articles.SearchAsync(new List<Expression<Func<Article, bool>>>
            {
                (a) => a.Title.Contains(keyword),
                (a) => a.Menu.Name.Contains(keyword),
                (a) => a.SeoDescription.Contains(keyword),
                (a) => a.SeoTags.Contains(keyword)
            },
            a => a.Menu, a => a.User);
            var searchedAndSortedArticles = isAscending
                ? searchedArticles.OrderBy(a => a.PublishDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : searchedArticles.OrderByDescending(a => a.PublishDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
            {
                Articles = searchedAndSortedArticles,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = searchedArticles.Count,
                IsAscending = isAscending
            });
        }


        public async Task<IResult> IncreaseViewCountAsync(Guid articleId)
        {
            var article = await UnitOfWork.Articles.GetAsync(a => a.Id == articleId);
            if (article == null)
            {
                return new Result(ResultStatus.Error, Messages.Article.NotFound(isPlural: false));
            }

            article.ViewsCount += 1;
            await UnitOfWork.Articles.UpdateAsync(article);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Article.IncreaseViewCount(article.Title));
        }
        public async Task<IDataResult<ArticleListDto>> GetAllByUserIdOnFilter(Guid userId, FilterBy filterBy, OrderBy orderBy, bool isAscending, int takeSize,
          Guid menuId, DateTime startAt, DateTime endAt, int minViewCount, int maxViewCount, int minCommentCount,
          int maxCommentCount)
        {
            var anyUser = await _userManager.Users.AnyAsync(u => u.Id == userId);
            if (!anyUser)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Error, $"{userId} numaralı kullanıcı bulunamadı.",
                    null);
            }

            var userArticles =
                await UnitOfWork.Articles.GetAllAsync(a => a.IsActive && !a.IsDeleted && a.UserId == userId);
            List<Article> sortedArticles = new List<Article>();
            switch (filterBy)
            {
                case FilterBy.Menu:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.MenuId == menuId).Take(takeSize)
                                    .OrderBy(a => a.Date).ToList()
                                : userArticles.Where(a => a.MenuId == menuId).Take(takeSize)
                                    .OrderByDescending(a => a.Date).ToList();
                            break;
                        case OrderBy.ViewCount:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.MenuId == menuId).Take(takeSize)
                                    .OrderBy(a => a.ViewsCount).ToList()
                                : userArticles.Where(a => a.MenuId == menuId).Take(takeSize)
                                    .OrderByDescending(a => a.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentCount:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.MenuId == menuId).Take(takeSize)
                                    .OrderBy(a => a.CommentCount).ToList()
                                : userArticles.Where(a => a.MenuId == menuId).Take(takeSize)
                                    .OrderByDescending(a => a.CommentCount).ToList();
                            break;
                    }
                    break;
                case FilterBy.Date:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                                    .OrderBy(a => a.PublishDate).ToList()
                                : userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                                    .OrderByDescending(a => a.PublishDate).ToList();
                            break;
                        case OrderBy.ViewCount:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                                    .OrderBy(a => a.ViewsCount).ToList()
                                : userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                                    .OrderByDescending(a => a.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentCount:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                                    .OrderBy(a => a.CommentCount).ToList()
                                : userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                                    .OrderByDescending(a => a.CommentCount).ToList();
                            break;
                    }
                    break;
                case FilterBy.ViewCount:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takeSize)
                                    .OrderBy(a => a.PublishDate).ToList()
                                : userArticles.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takeSize)
                                    .OrderByDescending(a => a.PublishDate).ToList();
                            break;
                        case OrderBy.ViewCount:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takeSize)
                                    .OrderBy(a => a.ViewsCount).ToList()
                                : userArticles.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takeSize)
                                    .OrderByDescending(a => a.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentCount:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takeSize)
                                    .OrderBy(a => a.CommentCount).ToList()
                                : userArticles.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takeSize)
                                    .OrderByDescending(a => a.CommentCount).ToList();
                            break;
                    }
                    break;
                case FilterBy.CommentCount:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sortedArticles = isAscending
                                ? userArticles.Where(a =>
                                        a.CommentCount >= minCommentCount && a.CommentCount <= maxCommentCount)
                                    .Take(takeSize)
                                    .OrderBy(a => a.PublishDate).ToList()
                                : userArticles.Where(a =>
                                        a.CommentCount >= minCommentCount && a.CommentCount <= maxCommentCount)
                                    .Take(takeSize)
                                    .OrderByDescending(a => a.PublishDate).ToList();
                            break;
                        case OrderBy.ViewCount:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.CommentCount >= minCommentCount && a.CommentCount <= maxCommentCount)
                                    .Take(takeSize)
                                    .OrderBy(a => a.ViewsCount).ToList()
                                : userArticles.Where(a => a.CommentCount >= minCommentCount && a.CommentCount <= maxCommentCount)
                                    .Take(takeSize)
                                    .OrderByDescending(a => a.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentCount:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.CommentCount >= minCommentCount && a.CommentCount <= maxCommentCount)
                                    .Take(takeSize)
                                    .OrderBy(a => a.CommentCount).ToList()
                                : userArticles.Where(a => a.CommentCount >= minCommentCount && a.CommentCount <= maxCommentCount)
                                    .Take(takeSize)
                                    .OrderByDescending(a => a.CommentCount).ToList();
                            break;
                    }

                    break;
            }

            return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
            {
                Articles = sortedArticles
            });
        }
        public async Task<IDataResult<ArticleDto>> GetByIdAsync(Guid articleId, bool includeMenu, bool includeComments, bool includeUser)
        {
            List<Expression<Func<Article, bool>>> predicates = new List<Expression<Func<Article, bool>>>();
            List<Expression<Func<Article, object>>> includes = new List<Expression<Func<Article, object>>>();
            if (includeMenu) includes.Add(a => a.Menu);
            if (includeComments) includes.Add(a => a.Comments);
            if (includeUser) includes.Add(a => a.User);
            predicates.Add(a => a.Id == articleId);
            var article = await UnitOfWork.Articles.GetAsyncV2(predicates, includes);
            if (article == null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Warning, Messages.General.ValidationError(), null,
                    new List<ValidationError>
                    {
                        new ValidationError
                        {
                            PropertyName = "articleId",
                            Message = Messages.Article.NotFoundById(articleId)
                        }
                    });
            }

            return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
            {
                Article = article
            });
        }

        public async Task<IDataResult<ArticleListDto>> GetAllAsyncV2(Guid? menuId, Guid? userId, bool? isActive, bool? isDeleted, int currentPage, int pageSize,
    OrderByGeneral orderBy, bool isAscending, bool includeMenu, bool includeComments, bool includeUser)
        {
            List<Expression<Func<Article, bool>>> predicates = new List<Expression<Func<Article, bool>>>();
            List<Expression<Func<Article, object>>> includes = new List<Expression<Func<Article, object>>>();

            //Predicates
            if (menuId.HasValue)
            {
                if (!await UnitOfWork.Menus.AnyAsync(m => m.Id == menuId.Value))
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Warning, Messages.General.ValidationError(), null,
                        new List<ValidationError>
                        {
                            new ValidationError
                            {
                                PropertyName = "menuId",
                                Message = Messages.Menu.NotFoundById(menuId.Value)
                            }
                        });
                }
                predicates.Add(a => a.MenuId == menuId.Value);
            }
            if (userId.HasValue)
            {
                if (!await _userManager.Users.AnyAsync(u => u.Id == userId.Value))
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Warning, Messages.General.ValidationError(), null,
                        new List<ValidationError>
                        {
                            new ValidationError
                            {
                                PropertyName = "userId",
                                Message = Messages.User.NotFoundById(userId.Value)
                            }
                        });
                }
                predicates.Add(a => a.UserId == userId.Value);
            }
            if (isActive.HasValue) predicates.Add(a => a.IsActive == isActive.Value);
            if (isDeleted.HasValue) predicates.Add(a => a.IsDeleted == isDeleted.Value);
            //Includes
            if (includeMenu) includes.Add(a => a.Menu);
            if (includeComments) includes.Add(a => a.Comments);
            if (includeUser) includes.Add(a => a.User);
            var articles = await UnitOfWork.Articles.GetAllAsyncV2(predicates, includes);

            IOrderedEnumerable<Article> sortedArticles;

            switch (orderBy)
            {
                case OrderByGeneral.Id:
                    sortedArticles = isAscending ? articles.OrderBy(a => a.Id) : articles.OrderByDescending(a => a.Id);
                    break;
                case OrderByGeneral.Az:
                    sortedArticles = isAscending ? articles.OrderBy(a => a.Title) : articles.OrderByDescending(a => a.Title);
                    break;
                // Default CreatedDate
                default:
                    sortedArticles = isAscending ? articles.OrderBy(a => a.CreatedDate) : articles.OrderByDescending(a => a.CreatedDate);
                    break;
            }

            return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
            {
                Articles = sortedArticles.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList(),
                MenuId = menuId.HasValue ? menuId.Value : null,
                CurrentPage = currentPage,
                PageSize = pageSize,
                IsAscending = isAscending,
                TotalCount = articles.Count,
                ResultStatus = ResultStatus.Success
            });

        }


    }
}
