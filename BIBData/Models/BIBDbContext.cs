using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;


namespace BIBData.Models
{
    public class BIBDbContext: DbContext
    {
        public DbSet<Lener> Leners { get; set; }
        public DbSet<Uitleenobject> Uitleenobjecten { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Boek> Boeken { get; set; }
        public DbSet<Reservering> Reserveringen { get; set; }
        public DbSet<Uitlening> Uitleningen { get; set; }
        public DbSet<Operatingsysteem> Operatingsystemen { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(
            configuration.GetConnectionString("BIBConnection"));
        }
        //nodig voor dotnet-ef tool
        public BIBDbContext()
        {

        }
        //voor de json file geinjecteerd w
        public BIBDbContext(DbContextOptions options):base(options)
        {

        }

    }
}
