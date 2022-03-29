using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectLast.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLast.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Information> Information { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<SSN> SSNs { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}
