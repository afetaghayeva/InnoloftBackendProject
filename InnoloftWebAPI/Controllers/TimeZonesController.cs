using InnoloftWebAPI.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace InnoloftWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeZonesController : ControllerBase
{
    private readonly ITimeZoneService _timeZoneService;

    public TimeZonesController(ITimeZoneService timeZoneService)
    {
        _timeZoneService = timeZoneService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var timeZones=_timeZoneService.GetTimeZones();
        return Ok(timeZones);
    }
}
