using eTickets.Data.Enums;
using eTickets.Models;

namespace eTickets.Data;

public class AppDBInitializer
{
    public static async Task Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var contex = serviceScope.ServiceProvider.GetService<AppDbContext>();

            contex.Database.EnsureCreated();

            //Cinema
            if (!contex.Cinemas.Any())
            {
                contex.Cinemas.AddRange(new List<Cinema>
                {
                    new Cinema
                    {
                        Name="Cinema 01",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                        Description = "This is the description of the 1st cinema"
                    },
                    new Cinema
                    {
                        Name="Cinema 02",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                        Description = "This is the description of the 2nd cinema"
                    },
                    new Cinema
                    {
                        Name="Cinema 03",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                        Description = "This is the description of the 3rd cinema"
                    },
                    new Cinema
                    {
                        Name="Cinema 04",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                        Description = "This is the description of the 4th cinema"
                    },
                    new Cinema
                    {
                        Name="Cinema 05",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                        Description = "This is the description of the 5th cinema"
                    },
                });
                await contex.SaveChangesAsync();
            }

            //Actors
            if (!contex.Actors.Any())
            {
                contex.Actors.AddRange(new List<Actor>
                {
                    new Actor
                    {
                        FullName = "Actor 01",
                        Bio = "This is the description of the 1st actor",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg",
                    },
                    new Actor
                    {
                        FullName = "Actor 02",
                        Bio = "This is the description of the 2nd actor",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg",
                    },
                    new Actor
                    {
                        FullName = "Actor 03",
                        Bio = "This is the description of the 3rd actor",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg",
                    },
                    new Actor
                    {
                        FullName = "Actor 04",
                        Bio = "This is the description of the 4th actor",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg",
                    },
                    new Actor
                    {
                        FullName = "Actor 05",
                        Bio = "This is the description of the 5th actor",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg",
                    },
                });
                await contex.SaveChangesAsync();
            }

            //Producers
            if (!contex.Producers.Any())
            {
                contex.Producers.AddRange(new List<Producer>
                {
                    new Producer
                    {
                        FullName = "Producer 01",
                        Bio = "This is the description of the 1st producer",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg",
                    },
                    new Producer
                    {
                        FullName = "Producer 02",
                        Bio = "This is the description of the 2nd producer",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg",
                    },
                    new Producer
                    {
                        FullName = "Producer 03",
                        Bio = "This is the description of the 3rd producer",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg",
                    },
                    new Producer
                    {
                        FullName = "Producer 04",
                        Bio = "This is the description of the 4th producer",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg",
                    },
                    new Producer
                    {
                        FullName = "Producer 05",
                        Bio = "This is the description of the 5th producer",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg",
                    },
                });
                await contex.SaveChangesAsync();
            }

            //Movies
            if (!contex.Movies.Any())
            {
                contex.Movies.AddRange(new List<Movie>
                {
                    new Movie
                    {
                        Name = "Life",
                        Description = "This is the Life movie description",
                        Price = 27.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                        StartDate = DateTime.Now.AddDays(-10),
                        EndDate = DateTime.Now.AddDays(10),
                        CinemaId = 3,
                        ProducerId = 3,
                        MovieCategory = MovieCategory.Documentary,
                    },
                    new Movie
                    {
                        Name = "The Shawshank Redemption",
                        Description = "This is the Shawshank Redemption movie description",
                        Price = 29.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(3),
                        CinemaId = 1,
                        ProducerId = 1,
                        MovieCategory = MovieCategory.Action,
                    },
                    new Movie
                    {
                        Name = "Ghost",
                        Description = "This is the Ghost movie description",
                        Price = 39.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(7),
                        CinemaId = 4,
                        ProducerId = 4,
                        MovieCategory = MovieCategory.Horror,
                    },
                    new Movie
                    {
                        Name = "Race",
                        Description = "This is the Race movie description",
                        Price = 41.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                        StartDate = DateTime.Now.AddDays(-10),
                        EndDate = DateTime.Now.AddDays(-5),
                        CinemaId = 1,
                        ProducerId = 2,
                        MovieCategory = MovieCategory.Documentary,
                    },
                    new Movie
                    {
                        Name = "Scoob",
                        Description = "This is the Scoob movie description",
                        Price = 35.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                        StartDate = DateTime.Now.AddDays(-10),
                        EndDate = DateTime.Now.AddDays(-2),
                        CinemaId = 1,
                        ProducerId = 3,
                        MovieCategory = MovieCategory.Cartoon,
                    },
                    new Movie
                    {
                        Name = "Cold Soles",
                        Description = "This is the Cold Soles movie description",
                        Price = 28.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                        StartDate = DateTime.Now.AddDays(3),
                        EndDate = DateTime.Now.AddDays(20),
                        CinemaId = 1,
                        ProducerId = 5,
                        MovieCategory = MovieCategory.Drama,
                    }
                });
                await contex.SaveChangesAsync();
            }


            //Actors & Movies
            if (!contex.Actors_Movies.Any())
            {
                contex.Actors_Movies.AddRange(new List<Actor_Movie>
                {
                    new Actor_Movie
                    {
                        ActorId = 1,
                        MovieId = 1
                    },
                    new Actor_Movie
                    {
                        ActorId = 3,
                        MovieId = 1
                    },
                    new Actor_Movie
                    {
                        ActorId = 1,
                        MovieId = 2
                    },
                    new Actor_Movie
                    {
                        ActorId = 4,
                        MovieId = 2
                    },
                    new Actor_Movie
                    {
                        ActorId = 1,
                        MovieId = 3
                    },
                    new Actor_Movie
                    {
                        ActorId = 2,
                        MovieId = 3
                    },
                    new Actor_Movie
                    {
                        ActorId = 5,
                        MovieId = 3
                    },
                    new Actor_Movie
                    {
                        ActorId = 2,
                        MovieId = 4
                    },
                    new Actor_Movie
                    {
                        ActorId = 3,
                        MovieId = 4
                    },
                    new Actor_Movie
                    {
                        ActorId = 4,
                        MovieId = 4
                    },
                    new Actor_Movie
                    {
                        ActorId = 2,
                        MovieId = 5
                    },
                    new Actor_Movie
                    {
                        ActorId = 3,
                        MovieId = 5
                    },
                    new Actor_Movie
                    {
                        ActorId = 4,
                        MovieId = 5
                    },
                    new Actor_Movie
                    {
                        ActorId = 5,
                        MovieId = 5
                    },
                    new Actor_Movie
                    {
                        ActorId = 3,
                        MovieId = 6
                    },
                    new Actor_Movie
                    {
                        ActorId = 4,
                        MovieId = 6
                    },
                    new Actor_Movie
                    {
                        ActorId = 5,
                        MovieId = 6
                    },
                });

                await contex.SaveChangesAsync();
            }
        }
    }
}
