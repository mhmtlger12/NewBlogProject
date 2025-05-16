namespace ProgrammersBlog.Shared.Entities.Abstract
{
    // Bu sınıf, diğer varlık sınıflarının (Entities) miras alacağı temel (base) bir sınıftır.
    // "abstract" olarak tanımlanmasının sebebi, doğrudan bir nesne olarak oluşturulmasını engellemek
    // ve sadece miras alınarak kullanılmasını sağlamaktır.
    public abstract class EntityBase
    {
        // Her varlığın benzersiz bir kimliği olmalıdır. Bu yüzden Guid kullanıyoruz.
        // "virtual" olarak işaretlendi, böylece türetilen sınıflarda "override" edilerek özelleştirilebilir.
        public virtual Guid Id { get; set; }

        // Nesnenin oluşturulma tarihini tutar. Varsayılan olarak şu anki tarih atanır.
        // "virtual" olduğu için istenirse türetilen sınıfta değiştirilebilir.
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;

        // Nesnenin son güncellenme tarihini tutar. Varsayılan olarak şu anki tarih atanır.
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Nesnenin silinip silinmediğini belirten bir flag (işaretçi) özelliğidir.
        // Varsayılan olarak "false" yani silinmemiş olarak başlar.
        public virtual bool IsDeleted { get; set; } = false;

        // Nesnenin aktif olup olmadığını belirten bir flag özelliğidir.
        // Varsayılan olarak "true" yani aktif olarak başlar.
        public virtual bool IsActive { get; set; } = true;

        // Nesneyi oluşturan kişinin adını tutar.
        public virtual string CreatedByName { get; set; } = "Admin";

        // Nesneyi en son güncelleyen kişinin adını tutar.
        public virtual string ModifiedByName { get; set; } = "Admin";

        public virtual string? Note { get; set; }
    }
}
