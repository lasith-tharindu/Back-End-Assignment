using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Framework.Database
{
    public partial class DatabaseContent : DbContext
    {
        public DatabaseContent(DbContextOptions<DatabaseContent> options)
           : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Department> Department { get; set; }

       
    }
}
