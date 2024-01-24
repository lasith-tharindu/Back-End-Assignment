using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Common.Common;
using WebApplication.Common.Models;
using WebApplication.Common.Utilities;
using WebApplication.Data;
using WebApplication.Data.Interfaces;
using WebApplication.Framework.Database;
using WebApplication.Services.Interfaces;

namespace WebApplication.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentServices(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public ActionResponse<DepartmentModal> DeleteDepartmentByDepartmentId(long id)
        {
            var result = new ActionResponse<DepartmentModal>();

            try
            {
                if (id != 0)
                {
                    var department = departmentRepository.DeleteDepartmentByDepartmentId(id);

                    if (department)
                    {
                        result.Message = "Department deleted successfully.";
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = "Department not deleted.";
                        result.Success = false;
                    }

                }
                else
                {
                    result.Success = false;
                    result.Message = "Should provide departmentId.";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public ActionResponse<DepartmentModal> EditDepartment(DepartmentModal departmentModal)
        {
            var result = new ActionResponse<DepartmentModal>();

            try
            {
                var department = departmentRepository.EditDepartment(departmentModal);

                result.Data = department;
                result.Success = true;
                result.Message = "Department updated successfully.";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public ActionResponse<IList<DepartmentModal>> GetAllDepartment()
        {
            var result = new ActionResponse<IList<DepartmentModal>>();

            try
            {
                var data = departmentRepository.GetAllDepartment();

                if (data.Count > 0)
                {
                    result.Data = data;
                    result.Success = true;
                    result.Message = "You have successfully obtained all departments.";
                }
                else
                {
                    result.Success = false;
                    result.Message = "There is no data found.";
                }

            }
            catch (Exception ex)
            {

                result.Data = new List<DepartmentModal>();
                result.Message = ex.Message;
            }

            return result;
        }

        public ActionResponse<DepartmentModal> GetDepartmentByDepartmentId(long id)
        {
            var result = new ActionResponse<DepartmentModal>();

            try
            {
                if (id != 0)
                {
                    var department = departmentRepository.GetDepartmentByDepartmentId(id);

                    if (department.Id > 0)
                    {
                        result.Data = department;
                        result.Success = true;
                        result.Message = "You have successfully obtained department.";
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
                    result.Message = "Should provide id.";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public ActionResponse<DepartmentModal> SaveDepartment(DepartmentModal departmentModal)
        {
            var result = new ActionResponse<DepartmentModal>();

            try
            {
                var department = departmentRepository.SaveDepartment(departmentModal);
                if (department.Id > 0)
                {
                    result.Data = department;
                    result.Success = true;
                    result.Message = "Department added successfully.";
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
