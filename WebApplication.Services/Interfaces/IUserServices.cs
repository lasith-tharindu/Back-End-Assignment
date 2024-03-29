﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Common.Common;
using WebApplication.Common.Models;

namespace WebApplication.Services.Interfaces
{
    public interface IUserServices
    {
        ActionResponse<IList<UserModal>> GetAllUser();
        ActionResponse<UserModal> SaveUser(UserModal userModal);
        ActionResponse<UserModal> EditUser(UserModal userModal);
        ActionResponse<UserModal> GetUserByUserId(long userId);
        ActionResponse<UserModal> DeleteUserByUserId(long userId);
    }
}
