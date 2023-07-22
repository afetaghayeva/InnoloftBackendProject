using InnofoltDataAccess.Entities;

namespace InnofoltDataAccess.Models;

public class PaginatedEvent
{
    public PaginatedEvent(IEnumerable<Event> items, int count, int pageNumber, int eventsPerPage)
    {
        PageInfo = new PageInfo
        {
            CurrentPage = pageNumber,
            EventsPerPage = eventsPerPage,
            TotalPages = (int)Math.Ceiling(count / (double)eventsPerPage),
            TotalEvents = count
        };
        this.Events = items;
    }

    public PageInfo PageInfo { get; set; }

    public IEnumerable<Event> Events { get; set; }

    public static PaginatedEvent ToPaginatedEvent(IQueryable<Event> events, int pageNumber, int eventsPerPage)
    {
        var count = events.Count();
        var chunk = events.Skip((pageNumber - 1) * eventsPerPage).Take(eventsPerPage);
        return new PaginatedEvent(chunk, count, pageNumber, eventsPerPage);
    }
}

public class PageInfo
{
    public bool HasPreviousPage
    {
        get
        {
            return (CurrentPage > 1);
        }
    }

    public bool HasNextPage
    {
        get
        {
            return (CurrentPage < TotalPages);
        }
    }

    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int EventsPerPage { get; set; }
    public int TotalEvents { get; set; }
}
