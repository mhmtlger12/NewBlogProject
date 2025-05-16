using ProgrammersBlog.Shared.Entities.Abstract;
using System.Linq.Expressions;

namespace ProgrammersBlog.Shared.Data.Abstract
{
    // IEntityRepository arayüzü, veritabanı işlemlerini soyutlamak için kullanılır.
    // T, bir sınıf olmalı (class), IEntity arayüzünü uygulamalı ve new() ile örneklenebilir olmalıdır.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {

        // Verilen bir koşula (predicate) göre tek bir kayıt getirir.
        // includeProperties, ilişkili tabloları dahil etmek için kullanılır.
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        // Verilen koşula göre (predicate) birden fazla kayıt getirir.
        // Eğer predicate null olursa, tüm kayıtları döndürür.
        // includeProperties, ilişkili tabloları dahil etmek için kullanılır.
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<IList<T>> GetAllAsyncV2(IList<Expression<Func<T, bool>>> predicates, IList<Expression<Func<T, object>>> includeProperties);
        // Yeni bir kayıt ekler.
        Task<T> AddAsync(T entity);

        // Mevcut bir kaydı günceller.
        Task<T> UpdateAsync(T entity);

        // Mevcut bir kaydı siler.
        Task DeleteAsync(T entity);

        // Verilen koşula (predicate) göre herhangi bir kayıt olup olmadığını kontrol eder.
        // Örneğin: AnyAsync(x => x.Email == "test@mail.com") şeklinde kullanılabilir.
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        // Verilen koşula göre kaç kayıt olduğunu döndürür.
        // Örneğin: CountAsync(x => x.IsActive) -> Aktif kullanıcı sayısını getirir.
        Task<int> CountAsync(Expression<Func<T, bool>> predicate=null);
        Task<IList<T>> SearchAsync(IList<Expression<Func<T, bool>>> predicates,
      params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetAsQueryable();
        Task<T> GetAsyncV2(IList<Expression<Func<T, bool>>> predicates, IList<Expression<Func<T, object>>> includeProperties);
        // if(isActive==true) predicates.Add()


    }
}
