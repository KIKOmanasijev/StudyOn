using StudyOn.Contracts.Models;
using StudyOn.Contracts.Requests;
using StudyOn.Data.Responses;
using System.Collections.Generic;

namespace StudyOn.Contracts.Managers
{
    public interface IMatchManager
    {
        Response<bool> AddMatch(AddMatchRequest request);
        Response<bool> JoinMatch(JoinMatchRequest request);
        Response<List<Matches>> GetMatch(GetMatchesRequest request);
    }
}
