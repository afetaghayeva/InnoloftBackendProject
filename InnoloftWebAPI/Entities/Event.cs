﻿using System.ComponentModel.DataAnnotations;

namespace InnoloftWebAPI.Entities;

public class Event
{
    public int Id { get; set; }
    public string EventName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string TimeZoneId { get; set; }
    public int UserId { get; set; }
    public virtual ICollection<Participant> Participants { get; set; }

}
