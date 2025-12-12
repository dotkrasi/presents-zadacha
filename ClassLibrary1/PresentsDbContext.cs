using Presents.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presents.Data
{
    public class PresentsDbContext : DbContext
    {
        public PresentsDbContext(DbContextOptions<PresentsDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gift> Gifts { get; set; }
    }
}
