namespace InnoloftWebAPI.Entities;

public class Participant
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int EventId { get; set; }

    public virtual Event Event { get; set; }
}
