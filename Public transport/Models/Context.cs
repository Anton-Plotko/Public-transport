﻿using Microsoft.EntityFrameworkCore;
using Public_transport.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Public_transport.Models
{
    public class Context : DbContext
    {   
        public DbSet<PublicTransport> Transports { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<RelationshipBetweenTransportsAndStops> Relationships { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Transport.db");
        }
    }
}
