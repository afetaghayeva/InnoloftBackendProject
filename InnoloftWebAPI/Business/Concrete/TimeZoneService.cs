using InnoloftWebAPI.Business.Abstract;
using InnoloftWebAPI.Models;

namespace InnoloftWebAPI.Business.Concrete;

public class TimeZoneService : ITimeZoneService
{
    public List<TimeZoneModel> GetTimeZones()
    {
        var list = new List<TimeZoneModel>();
        foreach (TimeZoneInfo tzInfo in TimeZoneInfo.GetSystemTimeZones())
        {
            TimeZoneModel model = new TimeZoneModel();
            model.Id = tzInfo.Id;
            model.DislplayName = tzInfo.DisplayName;

            list.Add(model);
        }

        return list;
    }
}
