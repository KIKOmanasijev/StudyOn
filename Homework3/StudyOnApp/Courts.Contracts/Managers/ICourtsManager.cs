using Court.Contracts.Models;
using Court.Contracts.Requests;
using Court.Contracts.Responses;
using System.Collections.Generic;

namespace Court.Contracts.Managers
{
    public interface ICourtsManager
    {
        Response<List<Courts>> GetCourt(GetCourtsRequest request);
        Response<bool> ReviewCourt(ReviewCourtRequest request);
    }
}
