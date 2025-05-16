using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Concrete;

namespace ProgrammersBlog.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection LoadMyServices(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddDbContext<ProgrammersBlogContext>();
            servicesCollection.AddIdentity<User, Role>(options =>
            {
                // Şifre (Password) Ayarları
                options.Password.RequireDigit = false; // Şifre içinde rakam (0-9) olma zorunluluğunu kapatır.
                options.Password.RequiredLength = 5; // Minimum şifre uzunluğunu 5 karakter olarak belirler.
                options.Password.RequiredUniqueChars = 0; // Şifrede kaç farklı karakter bulunması gerektiğini belirtir (0: sınır yok).
                options.Password.RequireNonAlphanumeric = false; // Şifre içinde özel karakter (!, @, #, vs.) olma zorunluluğunu kapatır.
                options.Password.RequireLowercase = false; // Şifre içinde küçük harf olma zorunluluğunu kapatır.
                options.Password.RequireUppercase = false; // Şifre içinde büyük harf olma zorunluluğunu kapatır.

                // Kullanıcı adı (UserName) Ayarları
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                // Kullanıcı adında kullanılmasına izin verilen karakterleri tanımlar.

                options.User.RequireUniqueEmail = true; // Her kullanıcı için benzersiz (tekil) e-posta adresi gerektirir.
            })
  // Identity yapılandırmasının Entity Framework tabanlı veri kaynağı olarak ProgrammersBlogContext kullanılmasını sağlar.
  .AddEntityFrameworkStores<ProgrammersBlogContext>();
            servicesCollection.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.Zero;
            });
            servicesCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            servicesCollection.AddScoped<ICategoryService, CategoryManager>();
            servicesCollection.AddScoped<IMenuService, MenuManager>();
            servicesCollection.AddScoped<IArticleService, ArticleManager>();
            servicesCollection.AddScoped<ICommentService, CommentManager>();
            servicesCollection.AddSingleton<IMailService, MailManager>();
            return servicesCollection;
        }
    }
}
