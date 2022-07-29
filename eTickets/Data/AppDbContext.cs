using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Way-1
        //modelBuilder.Entity<Actor>(c =>
        //{
        //    c.HasMany(t => t.Movies).WithMany(t => t.Actors).UsingEntity<Actor_Movie>(
        //        c => c.HasOne(t => t.Movie).WithMany().HasForeignKey(t => t.MovieId),
        //        d => d.HasOne(t => t.Actor).WithMany().HasForeignKey(t => t.ActorId));
        //});
        #endregion

        #region Way-2
        //modelBuilder.Entity<Actor_Movie>().HasKey(am => new
        //{
        //    am.ActorId,
        //    am.MovieId
        //});
        //modelBuilder.Entity<Actor_Movie>()
        //    .HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
        //modelBuilder.Entity<Actor_Movie>()
        //    .HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);
        #endregion

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Actor> Actors { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor_Movie> Actors_Movies { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Producer> Producers { get; set; }
}
