using InnoloftWebAPI.Entities;
using InnoloftWebAPI.Models;

namespace InnoloftWebAPI.DataAccess.Abstract;

public interface IParticipantDal
{
    PaginatedItem<Participant> GetParticipants(int eventId,int page = 0, int participantPerPage = 10);
    bool AddParticipant(Participant participant);
    bool Save();
}
