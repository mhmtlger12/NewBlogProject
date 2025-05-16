namespace ProgrammersBlog.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IArticleRepository Articles { get; }
        ICategoryRepository Categories { get; }
        IMenuRepository Menus { get; }
        ICommentRepository Comments { get; }
        ILogRepository Logs { get; }

        //_unitOfWork.Categories.AddAsync();

        //_unitOfWork.Categories.AddAsync(Category);
        //_unitOfWork.Categories.AddAsync(User);
        //_unitOfWork.SaveAsync();

        Task<int> SaveAsync();   
    }
}
