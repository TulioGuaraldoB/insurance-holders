using System;
using InsuranceHolders.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceHolders.Infra.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public virtual DbSet<Holder> Holders { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var host = Environment.GetEnvironmentVariable("DB_HOST");
            var name = Environment.GetEnvironmentVariable("DB_NAME");
            var user = Environment.GetEnvironmentVariable("DB_USER");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var dsn = $"server={host}; database={name}; user={user}; password={password}";
            options.UseMySql(dsn, ServerVersion.AutoDetect(dsn));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Holder>().
            HasKey(h => h.Id);
        }
    }
}