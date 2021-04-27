using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrophyCaseDataBase.Models;

namespace TrophyCaseDataBase.Data
{
    public class TrophyCaseDataBaseContext : DbContext
    {
        public TrophyCaseDataBaseContext (DbContextOptions<TrophyCaseDataBaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TrophyCaseDataBase.Models.Trophy> Trophy { get; set; }
    }
}
