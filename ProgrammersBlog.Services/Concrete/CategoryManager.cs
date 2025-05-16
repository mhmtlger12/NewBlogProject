using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos.Categories;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Utilities;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;


namespace ProgrammersBlog.Services.Concrete
{
    public class CategoryManager : ManagerBase, ICategoryService
    {


        /// <summary>
        /// CategoryManager sınıfının yapıcı metodu, bağımlılıkları enjekte eder.
        /// </summary>
        /// <param name="unitOfWork">Unit of Work nesnesi</param>
        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }


        /// <summary>
        /// Yeni bir kategori ekler.
        /// </summary>
        /// <param name="categoryAddDto">Kategori bilgilerini içeren DTO</param>
        /// <param name="createdByName">Oluşturan kişinin adı</param>
        /// <returns>İşlem sonucu</returns>
        public async Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = Mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;
            var addedCategory = await UnitOfWork.Categories.AddAsync(category);
            await UnitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success, message: Messages.Category.Add(addedCategory.Name),
                new CategoryDto
                {
                    Category = addedCategory,
                    ResultStatus = ResultStatus.Success,
                    Message = Messages.Category.Add(addedCategory.Name)
                });
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var categoriesCount = await UnitOfWork.Categories.CountAsync();
            if (categoriesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, categoriesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, message: $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var categoriesCount = await UnitOfWork.Categories.CountAsync(c => !c.IsDeleted);
            if (categoriesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, categoriesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, message: $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        /// <summary>
        /// Bir kategoriyi siler (Soft Delete - IsDeleted=true yapar).
        /// </summary>
        /// <param name="categoryId">Silinecek kategori ID'si</param>
        /// <param name="modifiedByName">Silme işlemini yapan kişinin adı</param>
        /// <returns>İşlem sonucu</returns>
        public async Task<IDataResult<CategoryDto>> DeleteAsync(Guid categoryId, string modifiedByName)
        {
            var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                category.IsDeleted = true;
                category.IsActive = false;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                var deletedCategory = await UnitOfWork.Categories.UpdateAsync(category);
                await UnitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(ResultStatus.Success, message: Messages.Category.Delete(deletedCategory.Name), new CategoryDto
                {
                    Category = deletedCategory,
                    ResultStatus = ResultStatus.Success,
                    Message = Messages.Category.Delete(deletedCategory.Name)
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, message: Messages.Category.NotFound(isPlural: false), new CategoryDto
            {
                Category = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Category.NotFound(isPlural: false)
            });
        }

        /// <summary>
        /// Belirtilen ID'ye sahip bir kategoriyi getirir.
        /// </summary>
        /// <param name="categoryId">Kategori ID'si</param>
        /// <returns>Kategori bilgisi</returns>
        public async Task<IDataResult<CategoryDto>> GetAsync(Guid categoryId)
        {
            //var query = UnitOfWork.Categories.GetAsQueryable();
            //query.Include(c => c.Articles).ThenInclude(a=>a.Comments);

            var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, message: Messages.Category.NotFound(isPlural: false), new CategoryDto
            {
                Category = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Category.NotFound(isPlural: false)
            });
        }

        /// <summary>
        /// Tüm kategorileri getirir.
        /// </summary>
        /// <returns>Kategori listesi</returns>
        public async Task<IDataResult<CategoryListDto>> GetAllAsync()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync(null);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }               //Burada istersek controller kısmında çözebiliriz erros message işini
            return new DataResult<CategoryListDto>(ResultStatus.Error, message: Messages.Category.NotFound(isPlural: true), new CategoryListDto
            { //burada ise views kısmında
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Category.NotFound(isPlural: true)
            });
        }

        /// <summary>
        /// Silinmemiş (IsDeleted=false) tüm kategorileri getirir.
        /// </summary>
        /// <returns>Silinmemiş kategorilerin listesi</returns>
        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAsync()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync(c => !c.IsDeleted);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }               //Burada istersek controller kısmında çözebiliriz erros message işini
            return new DataResult<CategoryListDto>(ResultStatus.Error, message: Messages.Category.NotFound(isPlural: true), new CategoryListDto
            { //burada ise views kısmında
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Category.NotFound(isPlural: true)
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync(c => !c.IsDeleted && c.IsActive);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDtoAsync(Guid categoryId)
        {
            var result = await UnitOfWork.Categories.AnyAsync(c => c.Id == categoryId);
            if (result)
            {
                var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
                var categoryUpdateDto = Mapper.Map<CategoryUpdateDto>(category);
                return new DataResult<CategoryUpdateDto>(ResultStatus.Success, categoryUpdateDto);
            }
            else
            {
                return new DataResult<CategoryUpdateDto>(ResultStatus.Error, message: Messages.Category.NotFound(isPlural: false), data: null);
            }
        }

        /// <summary>
        /// Bir kategoriyi kalıcı olarak veritabanından siler (Hard Delete).
        /// </summary>
        /// <param name="categoryId">Silinecek kategori ID'si</param>
        /// <returns>İşlem sonucu</returns>
        public async Task<IResult> HardDeleteAsync(Guid categoryId)
        {
            var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                await UnitOfWork.Categories.DeleteAsync(category);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, message: Messages.Category.HardDelete(category.Name));
            }
            return new Result(ResultStatus.Error, message: Messages.Category.NotFound(isPlural: false));
        }

        /// <summary>
        /// Bir kategoriyi günceller.
        /// </summary>
        /// <param name="categoryUpdateDto">Güncellenecek kategori bilgilerini içeren DTO</param>
        /// <param name="modifiedByName">Güncelleyen kişinin adı</param>
        /// <returns>İşlem sonucu</returns>
        public async Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var oldCategory = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.Id);
            var category = Mapper.Map<CategoryUpdateDto, Category>(categoryUpdateDto, oldCategory);
            category.ModifiedByName = modifiedByName;
            var updatedCategory = await UnitOfWork.Categories.UpdateAsync(category);
            await UnitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success, message: Messages.Category.Update(updatedCategory.Name), new CategoryDto
            {
                Category = updatedCategory,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Category.Update(updatedCategory.Name)
            });

        }
        public async Task<IDataResult<CategoryListDto>> GetAllByDeletedAsync()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync(c => c.IsDeleted);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: true), null);

        }


        public async Task<IDataResult<CategoryDto>> UndoDeleteAsync(Guid categoryId, string modifiedByName)
        {
            var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                category.IsDeleted = false;
                category.IsActive = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                var deletedCategory = await UnitOfWork.Categories.UpdateAsync(category);
                await UnitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(ResultStatus.Success, Messages.Category.UndoDelete(deletedCategory.Name), new CategoryDto
                {
                    Category = deletedCategory,
                    ResultStatus = ResultStatus.Success,
                    Message = Messages.Category.UndoDelete(deletedCategory.Name)
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: false), new CategoryDto
            {
                Category = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Category.NotFound(isPlural: false)
            });
        }
    }
}


