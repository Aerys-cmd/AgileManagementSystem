using AgileManagementSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Persistence.EF.Contexts
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContextFactory()
        {

        }
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-1AKBKH5;Database=AgileManagementDb;Trusted_Connection=true");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Project>()
                .HasMany(x => x.Contributors)
                .WithMany(x => x.Projects);

            //modelBuilder.Entity<Project>()
            //    .Property(x => x.Contributors)
            //    .HasField("_contributors")
            //    .UsePropertyAccessMode(PropertyAccessMode.Field);


            modelBuilder.Entity<Contributor>()
              .HasMany(x => x.Projects)
              .WithMany(x => x.Contributors);

            //modelBuilder.Entity<Contributor>()
            //   .Property(x => x.Projects)
            //   .HasField("_projects")
            //   .UsePropertyAccessMode(PropertyAccessMode.Field);

            base.OnModelCreating(modelBuilder);
        }
    }
}
