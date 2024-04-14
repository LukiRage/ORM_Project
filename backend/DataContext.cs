using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;
using static ORM_Projekt.DataBaseModels;

namespace ORM_Projekt
{
    public class DataContext : DbContext
    {
            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {
            }
            public DbSet<AirQuality> air_quality { get; set; }
            public DbSet<CO2Emission> co2_emission { get; set; }
            public DbSet<GDPGrowth> gdp_growth { get; set; }
            public DbSet<IndustryGrowth> industry { get; set; }
            public DbSet<Country> country_dictionary { get; set; }
            public DbSet<Year> year_dictionary { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));
                optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=projekt_db;Uid=root;Pwd=", serverVersion);
                base.OnConfiguring(optionsBuilder);

        }
    }
}
