using InnofoltDataAccess.Abstract;
using InnofoltDataAccess.Entities;
using InnofoltDataAccess.Models;

namespace InnofoltDataAccess.Concrete;

public class EfEventDal : IEventDal
{
    private readonly InnofoltDbContext _context;

    public EfEventDal(InnofoltDbContext context)
    {
        _context = context;
    }

    public PaginatedEvent GetAll(int page, int eventPerPage)
    {
        return PaginatedEvent.ToPaginatedEvent(_context.Events.OrderBy(x => x.Id), page, eventPerPage);
    }

    public bool Add(Event @event)
    {
        _context.Add(@event);
        return Save();
    }

    public bool Delete(Event @event)
    {
        _context.Remove(@event);
        return Save();
    }

    public Event GetById(int id) => _context.Events.FirstOrDefault(c => c.Id == id);

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }

    public bool Update(Event @event)
    {
        _context.Update(@event);
        return Save();
    }

}
