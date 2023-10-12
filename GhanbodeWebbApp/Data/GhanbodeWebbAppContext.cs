using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GhanbodeWebbApp.Models;

    public class GhanbodeWebbAppContext : DbContext
    {
        public GhanbodeWebbAppContext (DbContextOptions<GhanbodeWebbAppContext> options)
            : base(options)
        {
        }

        public DbSet<GhanbodeWebbApp.Models.FootballPlayers> FootballPlayers { get; set; }
    }
