using BoozeFitness.Models;
using BoozeFitness.Views;
using Microsoft.Data.Sqlite;
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
        private string connectionString = "Data Source=C:\\Users\\Andrew Vape\\source\\repos\\BoozeFitness\\BoozeFitness.Desktop\\sqlite.db";
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
            optionsBuilder.UseSqlite(connectionString);
        }
        public DbSet<User> Users { get; set; }
    }
}
