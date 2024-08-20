using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using MilitaryManagement.Model;

namespace MilitaryManagement.DAL
{
    public class AssetDBContext : DbContext
    {
        public AssetDBContext(DbContextOptions<AssetDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            //if (Database.EnsureCreated() && Friends.Count() == 0)
            //{
            //    Seed();
            //}
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new
                DbContextOptionsBuilder(), connectionString).Options;
        }


        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
    }
}

