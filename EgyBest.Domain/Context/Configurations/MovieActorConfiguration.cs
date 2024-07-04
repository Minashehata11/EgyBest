using EgyBest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgyBest.Domain.Context.Configurations
{
    public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(k => new { k.MovieId, k.ActorId });
            builder.HasOne(mg => mg.Actor).WithMany().HasForeignKey(mg => mg.ActorId);
            builder.HasOne(mg => mg.Movie).WithMany().HasForeignKey(mg => mg.MovieId);
        }
    }
}
