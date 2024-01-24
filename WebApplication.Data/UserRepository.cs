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
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContent databaseContent;

        public UserRepository(DatabaseContent databaseContent)
        {
            this.databaseContent = databaseContent;
        }

        public bool DeleteUserByUserId(long userId)
        {
            var findUser = databaseContent.Users.FirstOrDefault(x => x.Id == userId);
            if (findUser != null)
            {
                findUser.IsDeleted = true;
                databaseContent.Users.Update(findUser);
                databaseContent.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public UserModal EditUser(UserModal userModal)
        {
            var findUser = databaseContent.Users.FirstOrDefault(x => x.Id == userModal.Id);

            if (findUser != null)
            {
                findUser.Id = userModal.Id;
                findUser.Title = userModal.Title;
                findUser.FirstName = userModal.FirstName;
                findUser.LastName = userModal.LastName;
                findUser.Age = userModal.Age;
                findUser.Gender = userModal.Gender;
                findUser.Dob = userModal.Dob;
                findUser.Contact = userModal.Contact;
                findUser.Age = userModal.Age;
                findUser.Email = userModal.Email;
                findUser.Salary = userModal.Salary;
                findUser.DepartmentId = userModal.DepartmentId;
                findUser.CreateDated = userModal.CreateDated;
                findUser.ModifiyDate = DateTime.Now;

                databaseContent.Users.Update(findUser);
                databaseContent.SaveChanges();
            }

            return userModal;
        }

        public IList<UserModal> GetAllUser()
        {

            var userModelList = new List<UserModal>();

            var userEntity = databaseContent.Users.ToList();
            var departmentEnity = databaseContent.Department.ToList();

            var userQuery = (from u in userEntity
                             join d in departmentEnity on u.DepartmentId equals d.Id where d.IsDeleted != true && u.IsDeleted != true
                             select new
                             {
                                 Id = u.Id,
                                 Title = u.Title,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Gender = u.Gender,
                                 Dob = u.Dob,
                                 Contact = u.Contact,
                                 Age = u.Age,
                                 Email = u.Email,
                                 Salary = u.Salary,
                                 DepartmentId = u.DepartmentId,
                                 DepartmentName = d.Name,
                                 CreateDated = u.CreateDated
                             }).ToList();


            if (userQuery.Count != 0)
            {
                userModelList = userQuery.Select(x => new UserModal
                {
                    Id = x.Id,
                    Title = x.Title,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Gender = x.Gender,
                    Dob = x.Dob,
                    Contact = x.Contact,
                    Age = x.Age,
                    Email = x.Email,
                    Salary = x.Salary,
                    DepartmentId = x.DepartmentId,
                    CreateDated = x.CreateDated,
                    DepartmentName = x.DepartmentName

                }).ToList();
            }
            return userModelList;
        }

        public UserModal GetUserByUserId(long userId)
        {
            var userModelList = new UserModal();

            var userEntity = databaseContent.Users.ToList();
            var departmentEnity = databaseContent.Department.ToList();

            var userQuery = (from u in userEntity
                             join d in departmentEnity on u.DepartmentId equals d.Id where u.Id== userId && d.IsDeleted != true && u.IsDeleted != true
                             select new
                             {
                                 Id = u.Id,
                                 Title = u.Title,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Gender = u.Gender,
                                 Dob = u.Dob,
                                 Contact = u.Contact,
                                 Age = u.Age,
                                 Email = u.Email,
                                 Salary = u.Salary,
                                 DepartmentId = u.DepartmentId,
                                 DepartmentName = d.Name,
                                 CreateDated = u.CreateDated
                             }).FirstOrDefault();


            if (userQuery != null)
            {
                userModelList.Id = userQuery.Id;
                userModelList.Title = userQuery.Title;
                userModelList.FirstName = userQuery.FirstName;
                userModelList.LastName = userQuery.LastName;
                userModelList.Gender = userQuery.Gender;
                userModelList.Dob = userQuery.Dob;
                userModelList.Contact = userQuery.Contact;
                userModelList.Age = userQuery.Age;
                userModelList.Email = userQuery.Email;
                userModelList.Salary = userQuery.Salary;
                userModelList.DepartmentId = userQuery.DepartmentId;
                userModelList.CreateDated = userQuery.CreateDated;
                userModelList.DepartmentName = userQuery.DepartmentName;
                
            }
            return userModelList;
        }

        public UserModal SaveUser(UserModal userModal)
        {
            User user = new User();

            if (userModal.Id == 0)
            {

                user.Id = userModal.Id;
                user.Title = userModal.Title;
                user.FirstName = userModal.FirstName;
                user.LastName = userModal.LastName;
                user.Age = userModal.Age;
                user.Gender = userModal.Gender;
                user.Dob = userModal.Dob;
                user.Contact = userModal.Contact;
                user.Age = userModal.Age;
                user.Email = userModal.Email;
                user.Salary = userModal.Salary;
                user.DepartmentId = userModal.DepartmentId;
                user.CreateDated = userModal.CreateDated;
                user.IsDeleted = false;

                databaseContent.Users.Add(user);
                databaseContent.SaveChanges();

                userModal.Id = user.Id;
            }

            return userModal;

        }
    }
}
