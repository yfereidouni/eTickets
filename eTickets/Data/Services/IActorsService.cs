using eTickets.Models;

namespace eTickets.Data.Services;

public interface IActorsService
{
    Task<IEnumerable<Actor>> GetAll();
    Actor GetById(int id);
    void Add(Actor actor);
    void Update(int it, Actor newActor);
    void Delete(int id);
}
