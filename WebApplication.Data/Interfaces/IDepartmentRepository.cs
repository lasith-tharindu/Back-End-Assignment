using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Common.Models;
using WebApplication.Framework.Database;

namespace WebApplication.Data.Interfaces
{
    public interface IDepartmentRepository
    {
        IList<DepartmentModal> GetAllDepartment();
        DepartmentModal SaveDepartment(DepartmentModal departmentModal);
        DepartmentModal EditDepartment(DepartmentModal departmentModal);
        DepartmentModal GetDepartmentByDepartmentId(long id);
        DepartmentModal GetDepartmentByDepartmentName(string departmentName);
        bool DeleteDepartmentByDepartmentId(long id);
    }
}
