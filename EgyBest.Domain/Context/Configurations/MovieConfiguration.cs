using EgyBest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgyBest.Domain.Context.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasOne(m => m.Director).WithOne().HasForeignKey<Movie>(m => m.DirectorId);

        }
    }
}
