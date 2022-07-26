using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services;

public class ActorsService : IActorsService
{
    private readonly AppDbContext _context;

    public ActorsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Actor actor)
    {
        await _context.AddAsync(actor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var actor = await _context.Actors.FindAsync(id);
        _context.Actors.Remove(actor);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Actor>> GetAllAsync()
    {
        var result = await _context.Actors.ToListAsync();
        return result;
    }

    public async Task<Actor> GetByIdAsync(int id)
    {
        var actor = await _context.Actors.FirstOrDefaultAsync(c => c.Id == id);
        return actor;
    }

    public async Task UpdateAsync(int id, Actor newActor)
    {
        var actor = await _context.Actors.FindAsync(id);
        if (actor is not null)
        {
            actor.FullName = newActor.FullName;
            actor.Bio = newActor.Bio;
            actor.ProfilePictureURL = newActor.ProfilePictureURL;
        }
        else
        {
            actor = newActor;
        }

        _context.Update(actor);
        await _context.SaveChangesAsync();
    }
}
