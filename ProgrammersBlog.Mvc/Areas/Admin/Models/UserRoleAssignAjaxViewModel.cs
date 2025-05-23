﻿using ProgrammersBlog.Entities.Dtos.Roles;
using ProgrammersBlog.Entities.Dtos.UsersDto;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class UserRoleAssignAjaxViewModel
    {
        public UserRoleAssignDto UserRoleAssignDto { get; set; }
        public string RoleAssignPartial { get; set; }
        public UserDto UserDto { get; set; }
    }
}
