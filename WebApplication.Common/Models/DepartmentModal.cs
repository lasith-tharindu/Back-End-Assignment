using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Common.Models
{
    public class DepartmentModal
    {
        public long Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public DateTime CreateDated { get; set; }
        public DateTime? ModifiyDate { get; set; }
    }
}
