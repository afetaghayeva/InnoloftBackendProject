using InnofoltDataAccess;
using InnofoltDataAccess.Abstract;
using InnoloftWebAPI.Entities;
using InnoloftWebAPI.Models;

namespace InnoloftWebAPI.DataAccess.Concrete;

public class EfEventDal : IEventDal
{
    private readonly InnofoltDbContext _context;

    public EfEventDal(InnofoltDbContext context)
    {
        _context = context;
    }

    public PaginatedItem<Event> GetAll(int page, int eventPerPage)
       {
        return PaginatedItem<Event>.ToPaginatedItem(_context.Events.OrderBy(x => x.Id), page, eventPerPage);
    }

    public bool Add(Event @event)
    {
        _context.Add(@event);
        return Save();
    }
    public Event GetById(int id) => _context.Events.FirstOrDefault(c => c.Id == id);

    public bool Delete(int id)
    {
        var @event= this.GetById(id);
        _context.Remove(@event);
        return Save();
    }

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
