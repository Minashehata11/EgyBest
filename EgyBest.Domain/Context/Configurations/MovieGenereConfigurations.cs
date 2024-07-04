using EgyBest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgyBest.Domain.Context.Configurations
{
    public class MovieGenereConfigurations : IEntityTypeConfiguration<MovieGenere>
    {
        public void Configure(EntityTypeBuilder<MovieGenere> builder)
        {
            builder.HasKey(k=> new {k.MovieId,k.GenreId});
            builder.HasOne(mg => mg.Genere).WithMany().HasForeignKey(mg => mg.GenreId);
            builder.HasOne(mg => mg.Movie).WithMany().HasForeignKey(mg => mg.MovieId);
        }
    }
}
