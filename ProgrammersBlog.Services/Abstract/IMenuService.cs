using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos.Menus;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    /// <summary>
    /// Menü işlemlerini yöneten servis arayüzü.
    /// </summary>
    public interface IMenuService
    {
        /// <summary>
        /// Belirtilen ID'ye sahip menüyü getirir.
        /// </summary>
        /// <param name="menuId">Menü ID</param>
        /// <returns>İçinde menü nesnesi bulunan işlem sonucu</returns>
        Task<IDataResult<MenuDto>> GetAsync(Guid menuId);
        Task<IDataResult<MenuUpdateDto>> GetMenuUpdateDtoAsync(Guid menuId);
        Task<IDataResult<MenuListDto>> GetAllByDeletedAsync();
        /// <summary>
        /// Tüm menüleri getirir.
        /// </summary>
        /// <returns>Menü listesi</returns>
        Task<IDataResult<MenuListDto>> GetAllAsync();


        /// <summary>
        /// Silinmemiş tüm menüleri getirir. (IsDeleted = false)
        /// </summary>
        /// <returns>Silinmemiş menülerin listesini içeren sonuç.</returns>
        Task<IDataResult<MenuListDto>> GetAllByNonDeletedAsync();

        /// <summary>
        /// Hem silinmemiş hemde aktif
        /// </summary>
        /// <returns>Silinmemiş ve Aktif menülerin listesini içeren sonuç.</returns>
        Task<IDataResult<MenuListDto>> GetAllByNonDeletedAndActiveAsync();

        /// <summary>
        /// Üst menüye göre alt menüleri getirir
        /// </summary>
        /// <param name="parentId">Üst menü ID</param>
        /// <returns>Alt menülerin listesini içeren sonuç</returns>
        Task<IDataResult<MenuListDto>> GetAllByParentIdAsync(Guid parentId);

        /// <summary>
        /// Ana menüleri getirir (ParentId = null)
        /// </summary>
        /// <returns>Ana menülerin listesini içeren sonuç</returns>
        Task<IDataResult<MenuListDto>> GetAllMainMenusAsync();

        /// <summary>
        /// Yeni bir menü ekler.
        /// </summary>
        /// <param name="menuAddDto">Menü ekleme DTO'su</param>
        /// <param name="createdByName">Oluşturan kişinin adı</param>
        /// <returns>İşlem sonucu</returns>
        Task<IDataResult<MenuDto>> AddAsync(MenuAddDto menuAddDto, string createdByName);

        /// <summary>
        /// Mevcut bir menüyü günceller.
        /// </summary>
        /// <param name="menuUpdateDto">Menü güncelleme DTO'su</param>
        /// <param name="modifiedByName">Güncelleyen kişinin adı</param>
        /// <returns>İşlem sonucu</returns>
        Task<IDataResult<MenuDto>> UpdateAsync(MenuUpdateDto menuUpdateDto, string modifiedByName);

        /// <summary>
        /// Menüyü yumuşak silme (soft delete) işlemi yapar.
        /// (IsDeleted = true olarak işaretlenir.)
        /// </summary>
        /// <param name="menuId">Menü ID</param>
        /// <returns>İşlem sonucu</returns>
        Task<IDataResult<MenuDto>> DeleteAsync(Guid menuId, string modifiedByName);
        Task<IDataResult<MenuDto>> UndoDeleteAsync(Guid menuId, string modifiedByName);

        /// <summary>
        /// Menüyü tamamen siler. (Hard delete)
        /// Veritabanından tamamen kaldırılır.
        /// </summary>
        /// <param name="menuId">Menü ID</param>
        /// <returns>İşlem sonucu</returns>
        Task<IResult> HardDeleteAsync(Guid menuId);

        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
