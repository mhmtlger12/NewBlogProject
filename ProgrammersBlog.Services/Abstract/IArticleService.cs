using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Dtos.Articles;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;

namespace ProgrammersBlog.Services.Abstract
{
    public interface IArticleService
    {
        /// <summary>
        /// Belirtilen ID'ye sahip makaleyi getirir.
        /// </summary>
        /// <param name="articleId">Makale ID</param>
        /// <returns>İçinde makale nesnesi bulunan işlem sonucu</returns>
        Task<IDataResult<ArticleDto>> GetAsync(Guid articleId);
        Task<IDataResult<ArticleDto>> GetByIdAsync(Guid articleId, bool includeCategory, bool includeComments, bool includeUser);
        Task<IDataResult<ArticleUpdateDto>> GetArticleUpdateDtoAsync(Guid articleId);

        /// <summary>
        /// Tüm makaleleri getirir.
        /// </summary>
        /// <returns>Makale listesi</returns>
        Task<IDataResult<ArticleListDto>> GetAllAsync();

        /// <summary>
        /// Belirli bir menüye ait tüm makaleleri getirir.
        /// </summary>
        /// <returns>Menüye ait makalelerin listesi</returns>
        Task<IDataResult<ArticleListDto>> GetAllByMenuAsync(Guid menuId);


        /// <summary>
        /// Silinmemiş tüm makaleleri getirir. (IsDeleted = false)
        /// </summary>
        /// <returns>Silinmemiş makalelerin listesini içeren sonuç.</returns>
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAsync();


        /// <summary>
        /// Silinmemiş ve aktif olan tüm makaleleri getirir.
        /// </summary>
        /// <returns>Aktif ve silinmemiş makalelerin listesi</returns>
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActiveAsync();


        /// <summary>
        /// Yeni bir makale ekler.
        /// </summary>
        /// <param name="articleAddDto">Makaleyi eklemek için kullanılan DTO</param>
        /// <param name="createdByName">Makaleyi oluşturan kişinin adı</param>
        /// <returns>İşlem sonucu</returns>
        Task<IResult> AddAsync(ArticleAddDto articleAddDto, string createdByName,Guid UserId);

        /// <summary>
        /// Mevcut bir makaleyi günceller.
        /// </summary>
        /// <param name="articleUpdateDto">Makaleyi güncellemek için kullanılan DTO</param>
        /// <param name="modifiedByName">Makaleyi güncelleyen kişinin adı</param>
        /// <returns>İşlem sonucu</returns>
        Task<IResult> UpdateAsync(ArticleUpdateDto articleUpdateDto, string modifiedByName);

        /// <summary>
        /// Makaleyi yumuşak silme (soft delete) işlemi yapar.
        /// (IsDeleted = true olarak işaretlenir.)
        /// </summary>
        /// <param name="articleId">Makale ID</param>
        /// <param name="modifiedByName">Silme işlemini yapan kişinin adı</param>
        /// <returns>İşlem sonucu</returns>
        Task<IResult> DeleteAsync(Guid articleId, string modifiedByName);

        /// <summary>
        /// Makaleyi tamamen siler. (Hard delete)
        /// Veritabanından tamamen kaldırılır.
        /// </summary>
        /// <param name="articleId">Makale ID</param>
        /// <returns>İşlem sonucu</returns>
        Task<IResult> HardDeleteAsync(Guid articleId);

        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
        Task<IResult> UndoDeleteAsync(Guid articleId, string modifiedByName);
        Task<IDataResult<ArticleListDto>> GetAllByDeletedAsync();
        Task<IDataResult<ArticleListDto>> GetAllByViewCountAsync(bool isAscending, int? takeSize);
        Task<IDataResult<ArticleListDto>> GetAllByPagingAsync(Guid? menuId, int currentPage = 1, int pageSize = 5,
      bool isAscending = false);

        Task<IDataResult<ArticleListDto>> SearchAsync(string keyword, int currentPage = 1, int pageSize = 5,
    bool isAscending = false);

        Task<IResult> IncreaseViewCountAsync(Guid articleId);
        Task<IDataResult<ArticleListDto>> GetAllByUserIdOnFilter(Guid userId, FilterBy filterBy, OrderBy orderBy,
    bool isAscending, int takeSize, Guid menuId, DateTime startAt, DateTime endAt, int minViewCount,
    int maxViewCount, int minCommentCount, int maxCommentCount);

        Task<IDataResult<ArticleListDto>> GetAllAsyncV2(Guid? menuId, Guid? userId, bool? isActive, bool? isDeleted, int currentPage, int pageSize, OrderByGeneral orderBy, bool isAscending, bool includeMenu, bool includeComments, bool includeUser);
    }

}
