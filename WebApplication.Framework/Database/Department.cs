using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Framework.Database
{
    public partial class Department
    {

        public long Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDated { get; set; }
        public DateTime? ModifiyDate { get; set; }

    }
}
