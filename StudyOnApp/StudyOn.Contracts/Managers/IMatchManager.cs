using StudyOn.Contracts.Requests;
using StudyOn.Data.Responses;

namespace StudyOn.Contracts.Managers
{
    public interface IMatchManager
    {
        Response<bool> AddMatch(AddMatchRequest request);
        Response<bool> JoinMatch(JoinMatchRequest request);
    }
}
