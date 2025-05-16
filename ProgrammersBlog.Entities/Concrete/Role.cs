using Microsoft.AspNetCore.Identity;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Concrete
{
    // Rol sınıfı, EntityBase sınıfından miras alarak ortak özellikleri kullanır.
    // Ayrıca, IEntity arabirimini uygular.
    public class Role : IdentityRole<Guid>
    {
      

    }
}
