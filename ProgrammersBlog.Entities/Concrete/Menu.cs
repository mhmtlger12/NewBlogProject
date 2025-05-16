using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Concrete
{
    // Menü sınıfı, EntityBase sınıfından miras alarak ortak özellikleri kullanır.
    // Ayrıca, IEntity arabirimini uygular.
    public class Menu : EntityBase, IEntity
    {
        // Menünün adı
        public string Name { get; set; }

        // Menüye ait açıklama
        public string? Description { get; set; }

        // Menünün URL'si
        public string? Url { get; set; }

        // Menünün sırası
        public int Order { get; set; }

        // Menünün ikonu (Bootstrap veya başka bir ikon kütüphanesinden)
        public string? Icon { get; set; }

        // Eğer bu bir alt menü ise, üst menünün ID'si
        public Guid? ParentId { get; set; }

        // Navigation Property: Üst menü
        public Menu? Parent { get; set; }

        // Navigation Property: Alt menüler
        public ICollection<Menu>? SubMenus { get; set; }

        // Bir menünün birden fazla makalesi olabilir. (1'e N ilişki)
        public ICollection<Article>? Articles { get; set; }
    }
}
