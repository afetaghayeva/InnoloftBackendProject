using InnofoltDataAccess;
using InnoloftWebAPI.DataAccess.Abstract;
using InnoloftWebAPI.Entities;
using InnoloftWebAPI.Models;

namespace InnoloftWebAPI.DataAccess.Concrete;

public class EfParticipantDal : IParticipantDal
{
    private readonly InnofoltDbContext _context;

    public EfParticipantDal(InnofoltDbContext context)
    {
        _context = context;
    }

    public bool AddParticipant(Participant participant)
    {
        _context.Add(participant);
        return Save();
    }

    public PaginatedItem<Participant> GetParticipants(int eventId,int page = 0, int participantPerPage = 10)
    {
        var a = _context.Participants.Where(p=>p.Id==eventId);
        return PaginatedItem<Participant>.ToPaginatedItem(a, page, participantPerPage);
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
}
