﻿using ProgrammersBlog.Entities.Dtos.Categories;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class CategoryUpdateAjaxViewModel
    {
        public CategoryUpdateDto  CategoryUpdateDto { get; set; }
        public string CategoryUpdatePartial { get; set; }
        public CategoryDto CategoryDto  { get; set; }
    }
}
