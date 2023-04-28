using Microsoft.EntityFrameworkCore;
using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Persistence.Configurations.Entities
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            // ----- Varchar ------
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Role).IsRequired();
            builder.Property(p => p.Password).IsRequired();


            // ------ Index ------------
            builder.HasIndex(h => h.Email).IsUnique();

            // SEEDING DATA
            builder.HasData(
                    new User { Id = 1, Name = "Carlos Che", Age = 22, Email = "car123che@gmail.com", Phone = "41907419", Role = 1, Password = "admin" }
            );

        }
    }
}
