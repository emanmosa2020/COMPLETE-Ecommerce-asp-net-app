using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
             
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.MovieId,
                am.ActorId
            } );

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie)
                .WithMany(am => am.Actor_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m=>m.Actors)
                .WithMany(am=>am.Actor_Movies).HasForeignKey(m=>m.ActorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actors> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }    
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<Actor_Movie> actor_Movies { get; set; }
        public DbSet<Producer> producers { get; set; }
    }
}
