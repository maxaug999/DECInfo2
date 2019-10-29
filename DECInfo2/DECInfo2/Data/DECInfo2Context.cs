using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DECInfo2.Models;

namespace DECInfo2.Models
{
    public class DECInfo2Context : DbContext
    {
        public DECInfo2Context (DbContextOptions<DECInfo2Context> options)
            : base(options)
        {
        }

        public DbSet<DECInfo2.Models.Cours> Cours { get; set; }

        public DbSet<DECInfo2.Models.Prof> Prof { get; set; }
    }
}
