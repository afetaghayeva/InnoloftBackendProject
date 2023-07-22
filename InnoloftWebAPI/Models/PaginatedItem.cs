namespace InnoloftWebAPI.Models;

public class PaginatedItem<T>
{
    public PaginatedItem(IEnumerable<T> items, int count, int pageNumber, int itemsPerPage)
    {
        PageInfo = new PageInfo
        {
            CurrentPage = pageNumber,
            EventsPerPage = itemsPerPage,
            TotalPages = (int)Math.Ceiling(count / (double)itemsPerPage),
            TotalEvents = count
        };
        Items = items;
    }

    public PageInfo PageInfo { get; set; }

    public IEnumerable<T> Items { get; set; }

    public static PaginatedItem<T> ToPaginatedItem<T>(IQueryable<T> items, int pageNumber, int itemsPerPage)
    {
        var count = items.Count();
        var chunk = items.Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage);
        return new PaginatedItem<T>(chunk, count, pageNumber, itemsPerPage);
    }
}
