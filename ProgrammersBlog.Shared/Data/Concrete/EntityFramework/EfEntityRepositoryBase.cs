using LinqKit;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Shared.Data.Abstract;
using ProgrammersBlog.Shared.Entities.Abstract;
using System.Linq.Expressions;

namespace ProgrammersBlog.Shared.Data.Concrete.EntityFramework
{
    // EfEntityRepositoryBase<TEntity> sınıfı, Entity Framework Core ile temel CRUD işlemlerini gerçekleştirir.
    // TEntity, IEntity arayüzünü uygulayan ve new() ile örneklenebilir bir sınıf olmalıdır.
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly DbContext _context; // Veritabanı işlemlerinde kullanılacak DbContext

        // Constructor: Repository oluşturulurken DbContext enjekte edilir.
        public EfEntityRepositoryBase(DbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }


        // Verilen koşula uygun herhangi bir kayıt olup olmadığını kontrol eder.
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }

        // Verilen koşula uygun kayıtların toplam sayısını döndürür.
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate=null)
        {
            return await (predicate==null ? _context.Set<TEntity>().CountAsync(): _context.Set<TEntity>().CountAsync(predicate));
        }

        // Mevcut bir kaydı veritabanından siler.
        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Remove(entity); });
        }

        // Verilen koşula uygun tüm kayıtları getirir.
        // includeProperties: İlişkili tabloları dahil etmek için kullanılır.
        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            // Eğer bir filtreleme koşulu verilmişse, ona göre sorguyu daralt.
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            // Eğer ilişkili tablolar belirtilmişse, onları da sorguya dahil et.
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<IList<TEntity>> GetAllAsyncV2(IList<Expression<Func<TEntity, bool>>> predicates, IList<Expression<Func<TEntity, object>>> includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (predicates != null && predicates.Any())
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate); // isActive==false && isDeleted==true
                }
            }

            if (includeProperties != null && includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }

        // Verilen koşula uygun tek bir kaydı getirir.
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
             query = query.Where(predicate);
        

            // Eğer ilişkili tablolar belirtilmişse, onları da sorguya dahil et.
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().SingleOrDefaultAsync();
        }

        // Mevcut bir kaydı günceller.
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Update(entity); });
            return entity;
        }
        public async Task<IList<TEntity>> SearchAsync(IList<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (predicates.Any())
            {
                var predicateChain = PredicateBuilder.New<TEntity>();
                foreach (var predicate in predicates)
                {
                    // predicate1 && predicate2 && predicate3 && predicateN
                    // predicate1 || predicate2 || predicate3 || predicateN
                    predicateChain.Or(predicate);
                }

                query = query.Where(predicateChain);
            }

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }
        public IQueryable<TEntity> GetAsQueryable() //include yazmamamız gerekıosa 
        {
            return _context.Set<TEntity>().AsQueryable();
        }
        public async Task<TEntity> GetAsyncV2(IList<Expression<Func<TEntity, bool>>> predicates, IList<Expression<Func<TEntity, object>>> includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (predicates != null && predicates.Any())
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate); // isActive==false && isDeleted==true
                }
            }

            if (includeProperties != null && includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().SingleOrDefaultAsync();
        }
    }
}
