using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Common.Common;
using WebApplication.Common.Models;
using WebApplication.Common.Utilities;
using WebApplication.Data.Interfaces;
using WebApplication.Framework.Database;
using WebApplication.Services.Interfaces;

namespace WebApplication.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository userRepository;
        private readonly IDepartmentRepository departmentRepository;

        public UserServices(IUserRepository userRepository, IDepartmentRepository departmentRepository)
        {
            this.userRepository = userRepository;
            this.departmentRepository = departmentRepository;
        }

        public ActionResponse<UserModal> DeleteUserByUserId(long userId)
        {
            var result = new ActionResponse<UserModal>();

            try
            {
                if (userId != 0)
                {
                    var user = userRepository.DeleteUserByUserId(userId);

                    if (user)
                    {
                        result.Message = "User deleted successfully.";
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = "User not deleted.";
                        result.Success = false;
                    }

                }
                else
                {
                    result.Success = false;
                    result.Message = "Should provide userId.";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public ActionResponse<UserModal> EditUser(UserModal userModal)
        {
            var result = new ActionResponse<UserModal>();

            try
            {
                var user = userRepository.EditUser(userModal);

                result.Data = user;
                result.Success = true;
                result.Message = "User updated successfully.";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public ActionResponse<IList<UserModal>> GetAllUser()
        {
            var result = new ActionResponse<IList<UserModal>>();

            try
            {
                var data = userRepository.GetAllUser();

                if (data.Count > 0)
                {
                    result.Data = data;
                    result.Success = true;
                    result.Message = "You have successfully obtained all users.";
                }
                else
                {
                    result.Success = false;
                    result.Message = "There is no data found.";
                }
            }
            catch (Exception ex)
            {

                result.Data = new List<UserModal>();
                result.Message = ex.Message;
            }

            return result;
        }

        public ActionResponse<UserModal> GetUserByUserId(long userId)
        {
            var result = new ActionResponse<UserModal>();

            try
            {
                if (userId != 0)
                {
                    var user = userRepository.GetUserByUserId(userId);
                    if (user.Id > 0)
                    {
                        result.Data = user;
                        result.Success = true;
                        result.Message = "You have successfully obtained user.";
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "There is no data found.";
                    }

                }
                else
                {
                    result.Success = false;
                    result.Message = "Should provide userId.";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public ActionResponse<UserModal> SaveUser(UserModal userModal)
        {
            var result = new ActionResponse<UserModal>();

            try
            {
                var department = departmentRepository.GetDepartmentByDepartmentId(userModal.DepartmentId);
                if (department.Name != null)
                {
                    var user = userRepository.SaveUser(userModal);
                    if (user.Id > 0)
                    {
                        result.Data = user;
                        result.Success = true;
                        result.Message = "User added successfully.";
                    }
                }
                else
                {
                    result.Success = false;
                    result.Message = "There is no department found under the department ID you entered.";
                }
              

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
