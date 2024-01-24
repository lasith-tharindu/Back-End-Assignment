using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Common.Models;
using WebApplication.Data.Interfaces;
using WebApplication.Framework.Database;

namespace WebApplication.Data
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DatabaseContent databaseContent;

        public DepartmentRepository(DatabaseContent databaseContent)
        {
            this.databaseContent = databaseContent;
        }

        public bool DeleteDepartmentByDepartmentId(long id)
        {
            var findUser = databaseContent.Department.FirstOrDefault(x => x.Id == id && x.IsDeleted != true);
            if (findUser != null)
            {
                findUser.IsDeleted = true;
                databaseContent.Department.Update(findUser);
                databaseContent.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public DepartmentModal EditDepartment(DepartmentModal departmentModal)
        {
            var findDepartment = databaseContent.Department.FirstOrDefault(x => x.Id == departmentModal.Id);

            if (findDepartment != null)
            {

                findDepartment.Id = departmentModal.Id;
                findDepartment.Name = departmentModal.Name;
                findDepartment.Code = departmentModal.Code;
                findDepartment.ModifiyDate = DateTime.Now;

                databaseContent.Department.Update(findDepartment);
                databaseContent.SaveChanges();
            }

            return departmentModal;
        }

        public IList<DepartmentModal> GetAllDepartment()
        {

            var departmentEntity = databaseContent.Department.Where(x=> x.IsDeleted != true).ToList();

            var departmentModalList = new List<DepartmentModal>();

            departmentModalList = departmentEntity.Select(x => new DepartmentModal
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                CreateDated = x.CreateDated,
                ModifiyDate = x.ModifiyDate,


            }).ToList();

            return departmentModalList;
        }

        public DepartmentModal GetDepartmentByDepartmentId(long id)
        {
            var departmentModal = new DepartmentModal();

            var findDepartment = databaseContent.Department.FirstOrDefault(x => x.Id == id && x.IsDeleted != true);

            if (findDepartment != null)
            {
                departmentModal.Id = findDepartment.Id;
                departmentModal.Name = findDepartment.Name;
                departmentModal.Code = findDepartment.Code;
                departmentModal.CreateDated = findDepartment.CreateDated;
                departmentModal.ModifiyDate = findDepartment.ModifiyDate;
            }
            return departmentModal;
        }

        public DepartmentModal GetDepartmentByDepartmentName(string departmentName)
        {
            var departmentModal = new DepartmentModal();

            var findDepartment = databaseContent.Department.FirstOrDefault(x => x.Name == departmentName && x.IsDeleted != true);

            if (findDepartment != null)
            {
                departmentModal.Id = findDepartment.Id;
                departmentModal.Name = findDepartment.Name;
                departmentModal.Code = findDepartment.Code;
                departmentModal.CreateDated = findDepartment.CreateDated;
                departmentModal.ModifiyDate = findDepartment.ModifiyDate;
            }
            return departmentModal;
        }

        public DepartmentModal SaveDepartment(DepartmentModal departmentModal)
        {
            Department department = new Department();

            if (departmentModal.Id == 0)
            {
                department.Id = departmentModal.Id;
                department.Name = departmentModal.Name;
                department.Code = departmentModal.Code;
                department.CreateDated = DateTime.Now;

                databaseContent.Department.Add(department);
                databaseContent.SaveChanges();

                departmentModal.Id = department.Id;
            }

            return departmentModal;
        }
    }
}
