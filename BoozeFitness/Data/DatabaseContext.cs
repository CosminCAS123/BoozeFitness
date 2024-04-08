using BoozeFitness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.Data
{
    public class DatabaseContext : DbContext
    {
        private string connectionString = "Data Source=sqlite.db";
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);
        }
        public DbSet<User> Users { get; set; }
    }
}
