using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos.Menus;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Utilities;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;

namespace ProgrammersBlog.Services.Concrete
{
    public class MenuManager : ManagerBase, IMenuService
    {
        /// <summary>
        /// MenuManager sınıfının yapıcı metodu, bağımlılıkları enjekte eder.
        /// </summary>
        /// <param name="unitOfWork">Unit of Work nesnesi</param>
        public MenuManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Yeni bir menü ekler.
        /// </summary>
        /// <param name="menuAddDto">Menü bilgilerini içeren DTO</param>
        /// <param name="createdByName">Oluşturan kişinin adı</param>
        /// <returns>İşlem sonucu</returns>
        public async Task<IDataResult<MenuDto>> AddAsync(MenuAddDto menuAddDto, string createdByName)
        {
            var menu = Mapper.Map<Menu>(menuAddDto);
            menu.CreatedByName = createdByName;
            menu.ModifiedByName = createdByName;
            var addedMenu = await UnitOfWork.Menus.AddAsync(menu);
            await UnitOfWork.SaveAsync();
            return new DataResult<MenuDto>(ResultStatus.Success, message: Messages.Menu.Add(addedMenu.Name),
                new MenuDto
                {
                    Menu = addedMenu,
                    ResultStatus = ResultStatus.Success,
                    Message = Messages.Menu.Add(addedMenu.Name)
                });
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var menusCount = await UnitOfWork.Menus.CountAsync();
            if (menusCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, menusCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, message: $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var menusCount = await UnitOfWork.Menus.CountAsync(m => !m.IsDeleted);
            if (menusCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, menusCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, message: $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        /// <summary>
        /// Bir menüyü siler (Soft Delete - IsDeleted=true yapar).
        /// </summary>
        /// <param name="menuId">Silinecek menü ID'si</param>
        /// <param name="modifiedByName">Silme işlemini yapan kişinin adı</param>
        /// <returns>İşlem sonucu</returns>
        public async Task<IDataResult<MenuDto>> DeleteAsync(Guid menuId, string modifiedByName)
        {
            var menu = await UnitOfWork.Menus.GetAsync(m => m.Id == menuId);
            if (menu != null)
            {
                menu.IsDeleted = true;
                menu.IsActive = false;
                menu.ModifiedByName = modifiedByName;
                menu.ModifiedDate = DateTime.Now;
                var deletedMenu = await UnitOfWork.Menus.UpdateAsync(menu);
                await UnitOfWork.SaveAsync();
                return new DataResult<MenuDto>(ResultStatus.Success, message: Messages.Menu.Delete(deletedMenu.Name), new MenuDto
                {
                    Menu = deletedMenu,
                    ResultStatus = ResultStatus.Success,
                    Message = Messages.Menu.Delete(deletedMenu.Name)
                });
            }
            return new DataResult<MenuDto>(ResultStatus.Error, message: Messages.Menu.NotFound(isPlural: false), new MenuDto
            {
                Menu = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Menu.NotFound(isPlural: false)
            });
        }

        /// <summary>
        /// Belirtilen ID'ye sahip bir menüyü getirir.
        /// </summary>
        /// <param name="menuId">Menü ID'si</param>
        /// <returns>Menü bilgisi</returns>
        public async Task<IDataResult<MenuDto>> GetAsync(Guid menuId)
        {
            var menu = await UnitOfWork.Menus.GetAsync(m => m.Id == menuId, m => m.Articles, m => m.SubMenus);
            if (menu != null)
            {
                return new DataResult<MenuDto>(ResultStatus.Success, new MenuDto
                {
                    Menu = menu,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<MenuDto>(ResultStatus.Error, Messages.Menu.NotFound(isPlural: false), new MenuDto
            {
                Menu = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Menu.NotFound(isPlural: false)
            });
        }

        /// <summary>
        /// Tüm menüleri getirir.
        /// </summary>
        /// <returns>Menü listesi</returns>
        public async Task<IDataResult<MenuListDto>> GetAllAsync()
        {
            var menus = await UnitOfWork.Menus.GetAllAsync(null, m => m.Articles, m => m.SubMenus);
            if (menus.Count > -1)
            {
                return new DataResult<MenuListDto>(ResultStatus.Success, new MenuListDto
                {
                    Menus = menus,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<MenuListDto>(ResultStatus.Error, Messages.Menu.NotFound(isPlural: true), null);
        }

        /// <summary>
        /// Silinmemiş (IsDeleted=false) tüm menüleri getirir.
        /// </summary>
        /// <returns>Silinmemiş menülerin listesi</returns>
        public async Task<IDataResult<MenuListDto>> GetAllByNonDeletedAsync()
        {
            var menus = await UnitOfWork.Menus.GetAllAsync(m => !m.IsDeleted, m => m.Articles, m => m.SubMenus);
            if (menus.Count > -1)
            {
                return new DataResult<MenuListDto>(ResultStatus.Success, new MenuListDto
                {
                    Menus = menus,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<MenuListDto>(ResultStatus.Error, Messages.Menu.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<MenuListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var menus = await UnitOfWork.Menus.GetAllAsync(m => !m.IsDeleted && m.IsActive, m => m.Articles, m => m.SubMenus);
            if (menus.Count > -1)
            {
                return new DataResult<MenuListDto>(ResultStatus.Success, new MenuListDto
                {
                    Menus = menus,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<MenuListDto>(ResultStatus.Error, Messages.Menu.NotFound(isPlural: true), null);
        }

        /// <summary>
        /// Üst menüye göre alt menüleri getirir
        /// </summary>
        /// <param name="parentId">Üst menü ID</param>
        /// <returns>Alt menülerin listesini içeren sonuç</returns>
        public async Task<IDataResult<MenuListDto>> GetAllByParentIdAsync(Guid parentId)
        {
            var menus = await UnitOfWork.Menus.GetAllAsync(m => !m.IsDeleted && m.IsActive && m.ParentId == parentId, m => m.Articles);
            if (menus.Count > -1)
            {
                return new DataResult<MenuListDto>(ResultStatus.Success, new MenuListDto
                {
                    Menus = menus,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<MenuListDto>(ResultStatus.Error, Messages.Menu.NotFound(isPlural: true), null);
        }

        /// <summary>
        /// Ana menüleri getirir (ParentId = null)
        /// </summary>
        /// <returns>Ana menülerin listesini içeren sonuç</returns>
        public async Task<IDataResult<MenuListDto>> GetAllMainMenusAsync()
        {
            var menus = await UnitOfWork.Menus.GetAllAsync(m => !m.IsDeleted && m.IsActive && m.ParentId == null, m => m.SubMenus);
            if (menus.Count > -1)
            {
                return new DataResult<MenuListDto>(ResultStatus.Success, new MenuListDto
                {
                    Menus = menus,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<MenuListDto>(ResultStatus.Error, Messages.Menu.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<MenuUpdateDto>> GetMenuUpdateDtoAsync(Guid menuId)
        {
            var result = await UnitOfWork.Menus.AnyAsync(m => m.Id == menuId);
            if (result)
            {
                var menu = await UnitOfWork.Menus.GetAsync(m => m.Id == menuId);
                var menuUpdateDto = Mapper.Map<MenuUpdateDto>(menu);
                return new DataResult<MenuUpdateDto>(ResultStatus.Success, menuUpdateDto);
            }
            else
            {
                return new DataResult<MenuUpdateDto>(ResultStatus.Error, Messages.Menu.NotFound(isPlural: false), null);
            }
        }

        /// <summary>
        /// Bir menüyü kalıcı olarak veritabanından siler (Hard Delete).
        /// </summary>
        /// <param name="menuId">Silinecek menü ID'si</param>
        /// <returns>İşlem sonucu</returns>
        public async Task<IResult> HardDeleteAsync(Guid menuId)
        {
            var menu = await UnitOfWork.Menus.GetAsync(m => m.Id == menuId);
            if (menu != null)
            {
                await UnitOfWork.Menus.DeleteAsync(menu);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, message: Messages.Menu.HardDelete(menu.Name));
            }
            return new Result(ResultStatus.Error, message: Messages.Menu.NotFound(isPlural: false));
        }

        /// <summary>
        /// Bir menüyü günceller.
        /// </summary>
        /// <param name="menuUpdateDto">Güncellenecek menü bilgilerini içeren DTO</param>
        /// <param name="modifiedByName">Güncelleyen kişinin adı</param>
        /// <returns>İşlem sonucu</returns>
        public async Task<IDataResult<MenuDto>> UpdateAsync(MenuUpdateDto menuUpdateDto, string modifiedByName)
        {
            var oldMenu = await UnitOfWork.Menus.GetAsync(m => m.Id == menuUpdateDto.Id);
            var menu = Mapper.Map<MenuUpdateDto, Menu>(menuUpdateDto, oldMenu);
            menu.ModifiedByName = modifiedByName;
            var updatedMenu = await UnitOfWork.Menus.UpdateAsync(menu);
            await UnitOfWork.SaveAsync();
            return new DataResult<MenuDto>(ResultStatus.Success, message: Messages.Menu.Update(updatedMenu.Name), new MenuDto
            {
                Menu = updatedMenu,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Menu.Update(updatedMenu.Name)
            });
        }

        public async Task<IDataResult<MenuListDto>> GetAllByDeletedAsync()
        {
            var menus = await UnitOfWork.Menus.GetAllAsync(m => m.IsDeleted);
            if (menus.Count > -1)
            {
                return new DataResult<MenuListDto>(ResultStatus.Success, new MenuListDto
                {
                    Menus = menus,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<MenuListDto>(ResultStatus.Error, Messages.Menu.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<MenuDto>> UndoDeleteAsync(Guid menuId, string modifiedByName)
        {
            var menu = await UnitOfWork.Menus.GetAsync(m => m.Id == menuId);
            if (menu != null)
            {
                menu.IsDeleted = false;
                menu.IsActive = true;
                menu.ModifiedByName = modifiedByName;
                menu.ModifiedDate = DateTime.Now;
                var deletedMenu = await UnitOfWork.Menus.UpdateAsync(menu);
                await UnitOfWork.SaveAsync();
                return new DataResult<MenuDto>(ResultStatus.Success, Messages.Menu.UndoDelete(deletedMenu.Name), new MenuDto
                {
                    Menu = deletedMenu,
                    ResultStatus = ResultStatus.Success,
                    Message = Messages.Menu.UndoDelete(deletedMenu.Name)
                });
            }
            return new DataResult<MenuDto>(ResultStatus.Error, Messages.Menu.NotFound(isPlural: false), new MenuDto
            {
                Menu = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Menu.NotFound(isPlural: false)
            });
        }
    }
}
