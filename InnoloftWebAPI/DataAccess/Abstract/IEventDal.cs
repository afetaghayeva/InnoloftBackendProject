using InnoloftWebAPI.Entities;
using InnoloftWebAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InnofoltDataAccess.Abstract;

public interface IEventDal
{
    //Task<IPaginate<List<Event>>> GetAll(int page = 0, int eventPerPage = 10);
    PaginatedItem<Event> GetAll(int page = 0, int eventPerPage = 10);
    Event  GetById(int id);
    bool Add(Event @event);
    bool Update(Event @event);
    bool Delete(int id);
    bool Save();

}
