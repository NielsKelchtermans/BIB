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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(
            configuration.GetConnectionString("BIBConnection"));
        }

    }
}
