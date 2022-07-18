using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public abstract class BaseDbContext:DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options):base(options)
        {
        }
    }
}
