using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcPlaystations.Models;

    public class MvcPlaystationsContext : DbContext
    {
        public MvcPlaystationsContext (DbContextOptions<MvcPlaystationsContext> options)
            : base(options)
        {
        }

        public DbSet<MvcPlaystations.Models.Playstations> Playstations { get; set; }
    }
