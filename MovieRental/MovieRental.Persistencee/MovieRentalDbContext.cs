using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieRental.Domain;
using MovieRental.Domain.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Persistence
{
    public class MovieRentalDbContext : DbContext
    {
        public MovieRentalDbContext()
        {
            
        }

        public MovieRentalDbContext(DbContextOptions<MovieRentalDbContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-KAP3NP1H; Initial Catalog=MovieRental2; persist security info=True; Integrated Security=SSPI;")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging(); 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieRentalDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.UpdatedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Movie> Movies { get; set; }  //set or rules of reading a table
        public DbSet<Tag> Tags { get; set; }  //set or rules of reading a table
        public DbSet<MovieTag> MovieTags { get; set; }  //set or rules of reading a table
        public DbSet<User> Users { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Sell> Sells { get; set; }
    }
}
