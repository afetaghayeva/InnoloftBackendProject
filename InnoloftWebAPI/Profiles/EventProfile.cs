using AutoMapper;
using InnoloftWebAPI.Entities;
using InnoloftWebAPI.Models;

namespace InnoloftWebAPI.Profiles;

public class EventProfile: Profile
{
    public EventProfile()
    {
        CreateMap<AddEventModel, Event>();
        CreateMap<UpdateEventModel, Event>();
    }
}
