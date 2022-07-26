using eTickets.Data.Enums;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models;

public class Movie
{
    //[Key]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string ImageURL { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public MovieCategory MovieCategory { get; set; }

    //Relationships
    public List<Actor_Movie>? Actors_Movies { get; set; }


    //Cinema
    public int CinemaId { get; set; }
    public Cinema Cinema { get; set; }

    ////Producer
    public int ProducerId { get; set; }
    public Producer Producer { get; set; }

}
