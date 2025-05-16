using System.ComponentModel.DataAnnotations;

namespace ProgrammersBlog.Entities.ComplexTypes
{
    public enum FilterBy
    {
        [Display(Name = "Menü")]
        Menu = 0, //GetAllByUserIdOnDate(FilterBy=FilterBy.Menu,int menuId)
        [Display(Name = "Tarih")]
        Date = 1,
        [Display(Name = "Okunma Sayısı")]
        ViewCount = 2,
        [Display(Name = "Yorum Sayısı")]
        CommentCount = 3
    }
}
