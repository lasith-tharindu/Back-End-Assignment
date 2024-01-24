using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Common.Common;
using WebApplication.Common.Models;

namespace WebApplication.Services.Interfaces
{
    public interface IDepartmentServices
    {
        ActionResponse<IList<DepartmentModal>> GetAllDepartment();
        ActionResponse<DepartmentModal> SaveDepartment(DepartmentModal departmentModal);
        ActionResponse<DepartmentModal> EditDepartment(DepartmentModal departmentModal);
        ActionResponse<DepartmentModal> GetDepartmentByDepartmentId(long id);
        ActionResponse<DepartmentModal> DeleteDepartmentByDepartmentId(long id);
    }
}
