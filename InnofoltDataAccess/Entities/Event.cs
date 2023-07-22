namespace InnofoltDataAccess.Entities;

public class Event
{
    public int Id { get; set; }
    public string EventName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string TimeZone { get; set; }
}
