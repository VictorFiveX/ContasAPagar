using ContasAPagar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasAPagar.Infrastructure.Data
{
    public class DBConnectionContext : DbContext
    {
    public DBConnectionContext(DbContextOptions<DBConnectionContext> options)
    : base(options) { }


        public DbSet<ContaEntities> Contas { get; set; }
    }
}
