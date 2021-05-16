using BehinRahkar.Domain.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BehinRahkar.Persistence.EF
{
    public class EfDbContext : DbContext
    {
        private readonly IServiceProvider _services;

        public EfDbContext(
            DbContextOptions<EfDbContext> options,
            IServiceProvider services) : base(options)
        {
            _services = services;
        }

        public EfDbContext(DbContextOptions<EfDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Product> Products { get; set; }
    }
}
