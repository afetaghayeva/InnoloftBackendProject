using InnoloftWebAPI.Models;

namespace InnoloftWebAPI.Business.Abstract;

public interface ITimeZoneService
{
    List<TimeZoneModel> GetTimeZones();
}
