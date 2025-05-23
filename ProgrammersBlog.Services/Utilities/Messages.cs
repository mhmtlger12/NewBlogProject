

namespace ProgrammersBlog.Services.Utilities
{
    public static class Messages
    {

        public static class General
        {
            public static string ValidationError()
            {
                return $"Bir veya daha fazla validasyon hatası ile karşılaşıldı.";
            }
        }


        // Messages.Category.NotFound()
        public static class Category
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir kategori bulunamadı.";
                return "Böyle bir kategori bulunamadı.";
            }
            public static string NotFoundById(Guid categoryId)
            {
                return $"{categoryId} kategori koduna ait bir kategori bulunamadı.";
            }
            public static string Add(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla eklenmiştir.";
            }

            public static string Update(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla güncellenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla silinmiştir.";
            }
            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla arşivden geri getirilmiştir.";
            }
        }

        public static class Article
        {
            public static string NotFoundById(Guid articleId)
            {
                return $"{articleId} makale koduna ait bir makale bulunamadı.";
            }
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Makaleler bulunamadı.";
                return "Böyle bir makale bulunamadı.";
            }
            public static string Add(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla eklenmiştir.";
            }

            public static string Update(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla güncellenmiştir.";
            }
            public static string Delete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla silinmiştir.";
            }
            public static string HardDelete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla arşivden geri getirilmiştir.";
            }
            public static string IncreaseViewCount(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale'nin okunma sayısı başarıyla arttırılmıştır.";
            }

        }
        public static class Comment
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir yorum bulunamadı.";
                return "Böyle bir yorum bulunamadı.";
            }

            public static string Approve(Guid commentId)
            {
                return $"{commentId} no'lu yorum başarıyla onaylanmıştır.";
            }
            public static string Add(string createdByName)
            {
                return $"Sayın {createdByName}, yorumunuz başarıyla eklenmiştir.";
            }

            public static string Update(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla güncellenmiştir.";
            }
            public static string Delete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla silinmiştir.";
            }
            public static string HardDelete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla arşivden geri getirilmiştir.";
            }

        }
        public static class Menu
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir menü bulunamadı.";
                return "Böyle bir menü bulunamadı.";
            }
            public static string NotFoundById(Guid menuId)
            {
                return $"{menuId} menü koduna ait bir menü bulunamadı.";
            }
            public static string Add(string menuName)
            {
                return $"{menuName} adlı menü başarıyla eklenmiştir.";
            }

            public static string Update(string menuName)
            {
                return $"{menuName} adlı menü başarıyla güncellenmiştir.";
            }
            public static string Delete(string menuName)
            {
                return $"{menuName} adlı menü başarıyla silinmiştir.";
            }
            public static string HardDelete(string menuName)
            {
                return $"{menuName} adlı menü başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string menuName)
            {
                return $"{menuName} adlı menü başarıyla arşivden geri getirilmiştir.";
            }
        }
        
        public static class User
        {
            //public static string NotFound(bool isPlural)
            //{
            //    if (isPlural) return "Hiç bir kategori bulunamadı.";
            //    return "Böyle bir kategori bulunamadı.";
            //}
            public static string NotFoundById(Guid userId)
            {
                return $"{userId} kullanıcı koduna ait bir kullanıcı bulunamadı.";
            }
            //public static string Add(string categoryName)
            //{
            //    return $"{categoryName} adlı kategori başarıyla eklenmiştir.";
            //}

            //public static string Update(string categoryName)
            //{
            //    return $"{categoryName} adlı kategori başarıyla güncellenmiştir.";
            //}
            //public static string Delete(string categoryName)
            //{
            //    return $"{categoryName} adlı kategori başarıyla silinmiştir.";
            //}
            //public static string HardDelete(string categoryName)
            //{
            //    return $"{categoryName} adlı kategori başarıyla veritabanından silinmiştir.";
            //}
            //public static string UndoDelete(string categoryName)
            //{
            //    return $"{categoryName} adlı kategori başarıyla arşivden geri getirilmiştir.";
            //}
        }
    }
}
