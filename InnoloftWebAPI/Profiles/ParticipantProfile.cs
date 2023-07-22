using AutoMapper;
using InnoloftWebAPI.Entities;
using InnoloftWebAPI.Models;

namespace InnoloftWebAPI.Profiles;

public class ParticipantProfile:Profile
{
    public ParticipantProfile()
    {
        CreateMap<AddParticipantModel, Participant>();
    }
}
