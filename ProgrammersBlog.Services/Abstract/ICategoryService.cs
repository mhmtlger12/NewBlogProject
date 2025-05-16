using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos.Categories;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    /// <summary>
    /// Kategori işlemlerini yöneten servis arayüzü.
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Belirtilen ID'ye sahip kategoriyi getirir.
        /// </summary>
        /// <param name="categoryId">Kategori ID</param>
        /// <returns>İçinde kategori nesnesi bulunan işlem sonucu</returns>
        Task<IDataResult<CategoryDto>> GetAsync(Guid categoryId);
        Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDtoAsync(Guid categoryId);
        Task<IDataResult<CategoryListDto>> GetAllByDeletedAsync();
        /// <summary>
        /// Tüm kategorileri getirir.
        /// </summary>
        /// <returns>Kategori listesi</returns>
        Task<IDataResult<CategoryListDto>> GetAllAsync();


        /// <summary>
        /// Silinmemiş tüm kategorileri getirir. (IsDeleted = false)
        /// </summary>
        /// <returns>Silinmemiş kategorilerin listesini içeren sonuç.</returns>
        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAsync();

        /// <summary>
        /// Hem silinmemiş hemde aktif
        /// </summary>
        /// <returns>Silinmemiş ve Aktif kategorilerin listesini içeren sonuç.</returns>
        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActiveAsync();


        /// <summary>
        /// Yeni bir kategori ekler.
        /// </summary>
        /// <param name="categoryAddDto">Kategori ekleme DTO'su</param>
        /// <param name="createdByName">Oluşturan kişinin adı</param>
        /// <returns>İşlem sonucu</returns>
        Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto, string createdByName);

        /// <summary>
        /// Mevcut bir kategoriyi günceller.
        /// </summary>
        /// <param name="categoryUpdateDto">Kategori güncelleme DTO'su</param>
        /// <param name="modifiedByName">Güncelleyen kişinin adı</param>
        /// <returns>İşlem sonucu</returns>
        Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName);

        /// <summary>
        /// Kategoriyi yumuşak silme (soft delete) işlemi yapar.
        /// (IsDeleted = true olarak işaretlenir.)
        /// </summary>
        /// <param name="categoryId">Kategori ID</param>
        /// <returns>İşlem sonucu</returns>
        Task<IDataResult<CategoryDto>> DeleteAsync(Guid categoryId, string modifiedByName);
        Task<IDataResult<CategoryDto>> UndoDeleteAsync(Guid categoryId, string modifiedByName);

        /// <summary>
        /// Kategoriyi tamamen siler. (Hard delete)
        /// Veritabanından tamamen kaldırılır.
        /// </summary>
        /// <param name="categoryId">Kategori ID</param>
        /// <returns>İşlem sonucu</returns>
        Task<IResult> HardDeleteAsync(Guid categoryId);

        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
