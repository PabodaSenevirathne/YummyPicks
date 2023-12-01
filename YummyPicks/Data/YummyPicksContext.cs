using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YummyPicks.Models;

namespace YummyPicks.Data
{
    public class YummyPicksContext : DbContext
    {
        public YummyPicksContext (DbContextOptions<YummyPicksContext> options)
            : base(options)
        {
        }

        public DbSet<YummyPicks.Models.Review> Review { get; set; } = default!;
    }
}
