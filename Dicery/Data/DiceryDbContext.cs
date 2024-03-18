using Dicery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dicery.Data
{
    public class DiceryDbContext : DbContext
    {
        public DbSet<SystemError> Errors { get; set; }
        public DiceryDbContext(DbContextOptions options) : base(options) { }
       

        protected DiceryDbContext() { }
       
    }
}
