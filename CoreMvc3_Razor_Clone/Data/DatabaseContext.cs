using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreMvc3_Razor_Clone.Models;

namespace CoreMvc3_Razor_Clone.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<CoreMvc3_Razor_Clone.Models.Card> Card { get; set; }
    }
}
