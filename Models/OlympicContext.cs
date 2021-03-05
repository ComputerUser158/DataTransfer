using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dataTransfer.Models
{
    public class OlympicContext : DbContext
    {
        public OlympicContext(DbContextOptions<OlympicContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Sport> Sports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            {
                modelBuilder.Entity<Game>().HasData(
                    new Game { GameID = "wint", GameName = "Winter Olympics" },
                    new Game { GameID = "summ", GameName = "Summer Olympics" },
                    new Game { GameID = "para", GameName = "Paralympics" },
                    new Game { GameID = "youth", GameName = "Youth Olympic Games" }
                );
                modelBuilder.Entity<Sport>().HasData(
                    new Sport { SportID = "curl", SportName = "Curling/Indoor" },
                    new Sport { SportID = "bobsleigh", SportName = "Bobsleigh/Outdoor" },
                    new Sport { SportID = "dive", SportName = "Diving/Indoor" },
                    new Sport { SportID = "cycling", SportName = "Road Cycling/Outdoor" },
                    new Sport { SportID = "archery", SportName = "Archery/Indoor" },
                    new Sport { SportID = "canoe", SportName = "Canoe Sprint/Outdoor" },
                    new Sport { SportID = "dance", SportName = "Breakdancing/Indoor" },
                    new Sport { SportID = "skateboard", SportName = "Skateboarding/Outdoor" }
                );
                modelBuilder.Entity<Country>().HasData(
                    new { CountryID = "CA", CountryName = "Canada", SportID = "curl", GameID = "wint", FlagImage = "CA.png" },
                    new { CountryID = "SW", CountryName = "Sweden", SportID = "curl", GameID = "wint", FlagImage = "SW.png" },
                    new { CountryID = "GB", CountryName = "Great Britain", SportID = "curl", GameID = "wint", FlagImage = "GB.png" },
                    new { CountryID = "JA", CountryName = "Jamaica", SportID = "bobsleigh", GameID = "wint", FlagImage = "JA.png" },
                    new { CountryID = "IL", CountryName = "Italy", SportID = "bobsleigh", GameID = "wint", FlagImage = "IL.png" },
                    new { CountryID = "JP", CountryName = "Japan", SportID = "bobsleigh", GameID = "wint", FlagImage = "JP.png" },
                    new { CountryID = "GA", CountryName = "Germany", SportID = "dive", GameID = "summ", FlagImage = "GA.png" },
                    new { CountryID = "CN", CountryName = "China", SportID = "dive", GameID = "summ", FlagImage = "CN.png" },
                    new { CountryID = "MX", CountryName = "Mexico", SportID = "dive", GameID = "summ", FlagImage = "MX.png" },
                    new { CountryID = "BR", CountryName = "Brazil", SportID = "cycling", GameID = "summ", FlagImage = "BR.png" },
                    new { CountryID = "NL", CountryName = "Netherlands", SportID = "cycling", GameID = "summ", FlagImage = "NL.png" },
                    new { CountryID = "US", CountryName = "United States", SportID = "cycling", GameID = "summ", FlagImage = "US.png" },
                    new { CountryID = "TH", CountryName = "Thailand", SportID = "archery", GameID = "para", FlagImage = "TH.png" },
                    new { CountryID = "UY", CountryName = "Uruguay", SportID = "archery", GameID = "para", FlagImage = "UY.png" },
                    new { CountryID = "UA", CountryName = "Ukraine", SportID = "archery", GameID = "para", FlagImage = "UA.png" },
                    new { CountryID = "AT", CountryName = "Austria", SportID = "canoe", GameID = "para", FlagImage = "AT.png" },
                    new { CountryID = "PK", CountryName = "Pakistan", SportID = "canoe", GameID = "para", FlagImage = "PK.png" },
                    new { CountryID = "ZI", CountryName = "Zimbabwe", SportID = "canoe", GameID = "para", FlagImage = "ZI.png" },
                    new { CountryID = "FR", CountryName = "France", SportID = "dance", GameID = "youth", FlagImage = "FR.png" },
                    new { CountryID = "CY", CountryName = "Cyprus", SportID = "dance", GameID = "youth", FlagImage = "CY.png" },
                    new { CountryID = "RU", CountryName = "Russia", SportID = "dance", GameID = "youth", FlagImage = "RU.png" },
                    new { CountryID = "FI", CountryName = "Finland", SportID = "skateboard", GameID = "youth", FlagImage = "FI.png" },
                    new { CountryID = "SK", CountryName = "Slovakia", SportID = "skateboard", GameID = "youth", FlagImage = "SK.png" },
                    new { CountryID = "PT", CountryName = "Portugal", SportID = "skateboard", GameID = "youth", FlagImage = "PT.png" }
                );
            }
        }

    }
}