using EgyBest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EgyBest.Domain.Context
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genere> Generes { get; set; }
        public DbSet<MovieGenere> MovieGeneres { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }

    }
}
