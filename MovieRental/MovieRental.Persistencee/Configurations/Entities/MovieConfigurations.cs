using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Persistence.Configurations.Entities
{
    public class MovieConfigurations : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {

            // ----- Varchar ------
            builder.Property(p => p.Title).HasMaxLength(35);
            builder.Property(p => p.Description).HasMaxLength(100);
            builder.Property(p => p.TrailerLink).HasMaxLength(500);


            // ------ Index ------------
            builder.HasIndex(h => h.Title);
            builder.HasIndex(h => h.SalePrice);

            // SEEDING DATA
            builder.HasData(
                    new Movie { Id = 1, Title = "Avengers", Description = "Marvel Studios Avenger", Stock = 5, TrailerLink = "Avengers.com", SalePrice = 10.52, Likes = 80, Poster = "poster image", Availability = 1 },
                    new Movie { Id = 2, Title = "Avengers 2", Description = "Marvel Studios Avenger", Stock = 4, TrailerLink = "Avengers.com", SalePrice = 13.52, Likes = 90, Poster = "poster image", Availability = 1 },
                    new Movie { Id = 3, Title = "El origen", Description = "Dicaprio el origen", Stock = 30, TrailerLink = "ELROGINE.COM", SalePrice = 12.52, Likes = 50, Poster = "poster image", Availability = 1 },
                    new Movie { Id = 4, Title = "Nemo", Description = "Nemo nemo", Stock = 4, TrailerLink = "Nemo.com", SalePrice = 9.52, Likes = 70, Poster = "poster image", Availability = 1 }
            );

        }
    }
}
