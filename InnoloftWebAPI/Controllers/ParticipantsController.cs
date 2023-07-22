using AutoMapper;
using InnoloftWebAPI.DataAccess.Abstract;
using InnoloftWebAPI.Entities;
using InnoloftWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnoloftWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParticipantsController : ControllerBase
{
    private readonly IParticipantDal _participantDal;
    private readonly IMapper _mapper;

    public ParticipantsController(IParticipantDal participantDal, IMapper mapper)
    {
        _participantDal = participantDal;
        _mapper = mapper;
    }

    [HttpGet("{eventId}")]
    public IActionResult GetParticipants(int eventId, [FromQuery] QueryParams queryParams)
    {
        var participants=_participantDal.GetParticipants(eventId,queryParams.Page, queryParams.ItemsPerPage);
        return Ok(participants);
    }

    [HttpPost]
    public IActionResult AddParticipant(AddParticipantModel model)
    {
        var addedParticipant = _mapper.Map<Participant>(model);
        var newParticipant = _participantDal.AddParticipant(addedParticipant);
        return Ok(newParticipant);
    }
}
