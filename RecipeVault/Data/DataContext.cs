using System;
using Microsoft.EntityFrameworkCore;
using RecipeVault.Models;

namespace RecipeVault.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("RecipeDatabase"));
        }

        public DbSet<Recipes> Recipes { get; set; }
    }
}

