using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Data.Concrete.EntityFramework.Repositories;

namespace ProgrammersBlog.Data.Concrete
{
    // UnitOfWork sınıfı, birden fazla repository'nin bir arada çalışmasını ve veritabanı işlemlerinin yönetilmesini sağlayan bir yapıdır.
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProgrammersBlogContext _context;
        private EfArticleRepository _articleRepository;
        private EfCategoryRepository _categoryRepository;
        private EfMenuRepository _menuRepository;
        private EfCommentRepository _commentRepository;
        private EfLogRepository _logRepository;

        // UnitOfWork sınıfının yapıcı metodu. Burada bir DbContext (ProgrammersBlogContext) nesnesi alınır ve 
        // repository nesneleri onunla ilişkilendirilir.
        public UnitOfWork(ProgrammersBlogContext context)
        {
            _context = context; // DbContext'i bu sınıfa enjekte ediyoruz.
        }

        // Article verisiyle çalışacak repository'i sağlayan özellik.
        // Lazy loading yapılır, yani ilk kez ihtiyaç duyulduğunda nesne oluşturulur.
        public IArticleRepository Articles => _articleRepository ??= new EfArticleRepository(_context);

        // Category verisiyle çalışacak repository'i sağlayan özellik.
        public ICategoryRepository Categories => _categoryRepository ??= new EfCategoryRepository(_context);

        // Menu verisiyle çalışacak repository'i sağlayan özellik.
        public IMenuRepository Menus => _menuRepository ??= new EfMenuRepository(_context);

        // Comment verisiyle çalışacak repository'i sağlayan özellik.
        public ICommentRepository Comments => _commentRepository ??= new EfCommentRepository(_context);

        public ILogRepository Logs => _logRepository ??= new EfLogRepository(_context);



        // DisposeAsync metodu, kullanılan kaynakları serbest bırakmak için async olarak çağrılır.
        // Burada DbContext'in DisposeAsync metodu çağrılarak, bellek sızıntılarını engelleriz.
        public async ValueTask DisposeAsync()
        {
              GC.SuppressFinalize(this); // burası sonrada n eeklendı aslıdna yoktu.
            await _context.DisposeAsync(); // DbContext'i asenkron şekilde serbest bırakır.
        }

        // SaveAsync metodu, tüm değişiklikleri veritabanına kaydetmek için kullanılır.
        // Burada, DbContext'in SaveChangesAsync metodu çağrılır.
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync(); // Veritabanına yapılan değişiklikleri kaydeder.
        }
    }
}
