using System;
using System.Collections.Generic;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Menu : EntityBase, IEntity
    {
        public Menu()
        {
            SubMenus = new HashSet<Menu>();
            Articles = new HashSet<Article>();
        }

        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Url { get; set; }
        public int Order { get; set; }
        public string? Icon { get; set; }
        public Guid? ParentId { get; set; }

        // Navigation Properties
        public virtual Menu? Parent { get; set; }
        public virtual ICollection<Menu> SubMenus { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

        // EntityBase'den gelen özellikler:
        // public Guid Id { get; set; }
        // public DateTime CreatedDate { get; set; }
        // public DateTime ModifiedDate { get; set; }
        // public bool IsDeleted { get; set; }
        // public bool IsActive { get; set; }
        // public string CreatedByName { get; set; }
        // public string ModifiedByName { get; set; }
        // public string? Note { get; set; }
    }
}
