using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Framework.Database
{
    public partial class User
    {
       
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime Dob { get; set; }
        public string? Contact { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public decimal? Salary { get; set; }
        public long DepartmentId { get; set; }
        public DateTime CreateDated { get; set; }
        public DateTime? ModifiyDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
