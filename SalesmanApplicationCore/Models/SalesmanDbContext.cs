using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesmanApplicationCore.Models
{
    public class SalesmanDbContext : DbContext
    {
        public SalesmanDbContext(DbContextOptions<SalesmanDbContext> options) : base(options)
        {

        }
        public DbSet<Salesman> salesman { get; set; }
    }
}
