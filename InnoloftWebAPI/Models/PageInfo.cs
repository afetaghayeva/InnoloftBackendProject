namespace InnoloftWebAPI.Models;

public class PageInfo
{
    public bool HasPreviousPage
    {
        get
        {
            return CurrentPage > 1;
        }
    }

    public bool HasNextPage
    {
        get
        {
            return CurrentPage < TotalPages;
        }
    }

    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int EventsPerPage { get; set; }
    public int TotalEvents { get; set; }
}
